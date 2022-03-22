using Identity_API.DAL.Entities;
using Identity_API.UI.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages.Member
{
    public class UpdateWeaponModel : PageModel
    {
        private readonly IApiManager _apiManager;

        [BindProperty]
        public EldenRingWeapon EldenRingWeapon { get; set; }
        public List<EldenRingWeapon> WeaponList { get; set; }

        public UpdateWeaponModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }
        public async Task OnGet()
        {
            WeaponList = await _apiManager.GetWeaponsFromDb();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
           var msg = await _apiManager.UpdateWeaponFromDb(EldenRingWeapon);
            if (!String.IsNullOrEmpty(msg))
            {
                return RedirectToPage("/Index", new { PostMessage = msg });
            }
            else return Page();
        }
    }
}
