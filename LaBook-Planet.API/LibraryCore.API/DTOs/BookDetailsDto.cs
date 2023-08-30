using LaBook_Planet.API.Library.Domain.Models;

namespace LaBook_Planet.API.LibraryCore.API.DTOs
{
    public class BookDetailsDto
    {
        public string BookId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "";
        public string GenreId { get; set; } = "";
        public string Language { get; set; } = "";
        public int RatingValue { get; set; }
        public string ISBN { get; set; } = "";
        public DateTime DatePublished { get; set; }
        public int NumOfPages { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
