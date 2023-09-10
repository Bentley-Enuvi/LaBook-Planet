using LaBook_Planet.API.Library.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.DTOs
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        public string GenreId { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Isbn { get; set; }
        public int NumOfPages { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

    }
}
