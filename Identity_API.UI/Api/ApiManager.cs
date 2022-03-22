using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;

namespace Identity_API.UI.Api
{
    public class ApiManager : IApiManager
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string baseUrl = "https://localhost:7139/api/EldenRing";

        public ApiManager(SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> DeleteWeaponFromDb(int id)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            string url = String.Concat(baseUrl, $"/{id}?accessToken={currentUser.AccessToken}");

            using (var client = new HttpClient())
            {
                using(var response = await client.DeleteAsync(url))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        return apiResponse;
                    }
                    else return null;
                }
            }
        }

        public async Task<List<EldenRingWeapon>> GetWeaponsFromDb()
        {

            //Api-call to web api to get a list of weapons from the database.
            //Send a access token for verification that user exists in AuthdB.
            //HttpContextAccessor is injected in to get current user logged in's access token...I think.

            List<EldenRingWeapon> weapons = new();
            var currentUser = await _signInManager.UserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            string url = String.Concat(baseUrl, $"?accessToken={currentUser.AccessToken}");

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        weapons = JsonConvert.DeserializeObject<List<EldenRingWeapon>>(apiResponse);
                        return weapons;
                    }
                    else return null;
                }
            }
        }

        public async Task<string> PostWeaponToDb(EldenRingWeapon weapon)
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            string url = String.Concat(baseUrl, $"?accessToken={currentUser.AccessToken}");

            using (var httpClient = new HttpClient())
            {
                var newPostJson = JsonConvert.SerializeObject(weapon);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(url, payload).Result.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}
