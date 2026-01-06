using System.ComponentModel.DataAnnotations;

namespace ShopTARge24.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and conformation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Token { get; set; }
    }
}
