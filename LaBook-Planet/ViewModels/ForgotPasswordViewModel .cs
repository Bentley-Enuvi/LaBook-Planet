using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

    }
}
