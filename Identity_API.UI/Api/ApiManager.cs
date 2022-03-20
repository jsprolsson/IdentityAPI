using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

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

        public async Task<List<EldenRingWeapon>> GetWeaponsFromDb()
        {
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
    }
}
