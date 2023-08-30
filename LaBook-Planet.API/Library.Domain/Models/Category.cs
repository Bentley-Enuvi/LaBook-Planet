using LaBook_Planet.API.Library.Domain.Services.Interfaces;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class Category : IEntity, IAuditable
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
