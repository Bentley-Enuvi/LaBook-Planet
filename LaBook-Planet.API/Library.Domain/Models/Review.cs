using LaBook_Planet.API.Library.Domain.Services.Interfaces;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class Review : IEntity, IAuditable
    {
        public string Id { get; set; } = "";
        public string BookId { get; set; } = "";
        public string Title { get; set; } = "";
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Book Book { get; set; }
    }
}
