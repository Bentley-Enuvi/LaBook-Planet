using LaBook_Planet.API.Library.Domain.Enums;

namespace LaBook_Planet.API.LibraryCore.API.DTOs
{
    public class GetAllBooksDto
    {
        public string BookId { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Image { get; set; } = "";
        public int RatingValue { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string NumOfPages { get; set; }
        public DateTime DatePublished { get; set; }
        public int AvailableCopies { get; set; }

        public bool IsAvailable { get; set; }
    }
}
