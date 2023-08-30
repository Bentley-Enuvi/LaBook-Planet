using LaBook_Planet.API.Library.Domain.Enums;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class Book : IEntity, IAuditable
    {
        public string Id { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int AvailableCopies { get; internal set; }
    }
}
