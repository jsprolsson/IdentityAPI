using System.ComponentModel.DataAnnotations;

namespace Identity_API.UI.ViewModels
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Username needed!")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password needed!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Verified password needed!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords doesn't match")]
        public string? VerifiedPassword { get; set; }
    }
}
