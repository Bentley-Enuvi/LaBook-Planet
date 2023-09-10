using LaBook_Planet.API.Library.Domain.Services.Interfaces;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class CartItems : IEntity
    {
        public string Id { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
    }
}
