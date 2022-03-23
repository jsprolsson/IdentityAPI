using Identity_API.DAL;
using Identity_API.DAL.Entities;
using Identity_API.UI.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class AddWeaponModel : PageModel
    {
        private readonly IApiManager _apiManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public EldenRingWeapon Weapon { get; set; }

        public AddWeaponModel(IApiManager apiManager, SignInManager<ApplicationUser> signInManager)
        {
            _apiManager = apiManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //Gets the user currently signed in and assigns the users identity-id to the weapon.
            var currentUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
            Weapon.WeaponOwnerId = currentUser.Id;

            //Posts weapon to db.
            string msg = await _apiManager.PostWeaponToDb(Weapon);
            return RedirectToPage("/Index", new { PostMessage = msg });
        }
    }
}
