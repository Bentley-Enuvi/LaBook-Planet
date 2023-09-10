using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string author { get; set; } = "";

        [Required]
        public string Descripion { get; set; } = "";
        public DateTime DatePublished { get; set; }
    }
}
