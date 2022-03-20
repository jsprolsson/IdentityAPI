using Identity_API.DAL.Entities;
using Identity_API.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        [BindProperty]
        public LoginUserModel? LoginUser { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Message { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostLogin()
        {

            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(LoginUser.UserName, LoginUser.Password, true, false);

                if (signInResult.Succeeded)
                {
                    var currentUser = await _signInManager.UserManager.FindByNameAsync(LoginUser.UserName);
                    currentUser.LastLoggedIn = DateTime.Now;
                    currentUser.AccessToken = BLL.AppManager.CreateAccessToken();
                    await _signInManager.UserManager.UpdateAsync(currentUser);
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
