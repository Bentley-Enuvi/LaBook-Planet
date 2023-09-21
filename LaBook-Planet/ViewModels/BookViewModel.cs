using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Author { get; set; } = "";

        [Required]
        public string Descripion { get; set; } = "";
        public DateTime DatePublished { get; set; }

        public string Image { get; set; }
        public string NumOfPages { get; set; }
        public string UserId { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string GenreId { get; set; }
        public string TotalCopies { get; set; }
        public string PublishedAt { get; set; }
        public string AvailableCopies { get; set; }
    }
}
