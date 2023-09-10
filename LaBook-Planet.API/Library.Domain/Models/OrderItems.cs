using LaBook_Planet.API.Library.Domain.Services.Interfaces;

namespace LaBook_Planet.API.Library.Domain.Models
{
    public class OrderItems : IEntity
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public string OrderId { get; set; }
        public string BookId { get; set; }
        public Orders Order { get; set; }
        public Book Book { get; set; }

    }
}
