using Identity_API.DAL;
using Identity_API.DAL.Entities;
using Identity_API.UI.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class AddWeaponModel : PageModel
    {
        private readonly IApiManager _apiManager;

        [BindProperty]
        public EldenRingWeapon Weapon { get; set; }

        public AddWeaponModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string msg = await _apiManager.PostWeaponToDb(Weapon);
            return RedirectToPage("/Index", new { PostMessage = msg });
        }
    }
}
