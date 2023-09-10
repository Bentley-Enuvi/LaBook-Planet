using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class UserRoleViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Id { get; internal set; }
    }
}
