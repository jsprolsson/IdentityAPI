using System.ComponentModel.DataAnnotations;

namespace Identity_API.UI.ViewModels
{
    public class LoginUserModel
    {
        [Required(ErrorMessage="Incorrect username.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage="Password needed!")]
        public string? Password { get; set; }
    }
}
