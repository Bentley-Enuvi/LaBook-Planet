using LaBook_Planet.API.Library.Domain.Services.Interfaces;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class Orders : IEntity
    {
        public string Id { get; set; }
        public List<OrderItems> OrderItems { get; set; } = new();
        public int TotalOrder { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
