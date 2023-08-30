using LaBook_Planet.API.Library.Domain.Models;

namespace LaBook_Planet.API.LibraryCore.API.DTOs
{
    public class ReturnBookDto
    {
        public string Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "";
        public string GenreId { get; set; } = "";
        public string Language { get; set; } = "";
        public string ISBN { get; set; } = "";
        public DateTime DatePublished { get; set; }
        public int NumOfPages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
