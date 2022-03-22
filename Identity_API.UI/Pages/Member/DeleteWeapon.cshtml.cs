using Identity_API.UI.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity_API.UI.Pages.Member
{
    public class DeleteWeaponModel : PageModel
    {
        private readonly IApiManager _apiManager;
        [BindProperty]
        public int IDToDelete { get; set; }

        public DeleteWeaponModel(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var msg = await _apiManager.DeleteWeaponFromDb(IDToDelete);
            return RedirectToPage("/Index", new { PostMessage = msg });
        }
    }
}
