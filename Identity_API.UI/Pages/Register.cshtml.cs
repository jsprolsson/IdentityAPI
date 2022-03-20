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
                ApplicationUser user = new();

                user.UserName = RegisterUser.Username;
                user.DateRegistered = DateTime.Now;

                var result = await _userManager.CreateAsync(user, RegisterUser.Password);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Login", new { Message = "User created! Please login." });
                }

            }

            return Page();
        }
    }
}
