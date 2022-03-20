using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public bool LogOut { get; set; }

        public LogOutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostDontLogOut()
        {
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostLogOut()
        {
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);
            currentUser.AccessToken = null;
            await _signInManager.UserManager.UpdateAsync(currentUser);
            await _signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
