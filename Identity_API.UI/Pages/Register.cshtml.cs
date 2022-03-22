using Identity_API.DAL.Entities;
using Identity_API.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public RegisterUserModel? RegisterUser { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostRegisterUser()
        {
            if (ModelState.IsValid)
            {

                //Creates user.
                ApplicationUser user = new();

                user.UserName = RegisterUser.Username;
                user.DateRegistered = DateTime.Now;

                var result = await _userManager.CreateAsync(user, RegisterUser.Password);

                //If user creation successful, redirects to login page with message.
                if (result.Succeeded)
                {
                    return RedirectToPage("/Login", new { Message = "User created! Please login." });
                }

            }

            return Page();
        }
    }
}
