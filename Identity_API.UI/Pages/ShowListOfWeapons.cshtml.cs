using Identity_API.DAL.Entities;
using Identity_API.UI.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class ShowListOfWeaponsModel : PageModel
    {
        private readonly IApiManager _apiManager;

        public List<EldenRingWeapon> weapons { get; set; } = null;

        public ShowListOfWeaponsModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        public async Task OnGet()
        {
            weapons = await _apiManager.GetWeaponsFromDb();
        }
    }
}
