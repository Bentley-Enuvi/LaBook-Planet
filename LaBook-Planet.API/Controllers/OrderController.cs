using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.TeamFoundation.Build.WebApi;

namespace LaBook_Planet.API.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly LaBookContextApi _context;
        private readonly Cart _cart;

        public OrderController(LaBookContextApi context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Orders order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Please select items to add to cart.");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return View("CheckoutComplete", order);
            }

            return View(order);
        }

        public IActionResult CheckoutComplete(Orders order)
        {
            return View(order);
        }

        public void CreateOrder(Orders order)
        {
            order.OrderPlaced = DateTime.Now;

            var cartItems = _cart.CartItems;

            var orderItem = new Orders();
            _context.Orders.Add(orderItem);
            _context.SaveChanges();  // Save changes to get the order Id

            foreach (var item in cartItems)
            {
                var itemOrdered = new OrderItems()
                {
                    Quantity = item.Quantity,
                    Book = item.Book,
                    OrderId = orderItem.Id,  // Use the Id obtained from the saved order
                    Price = item.Book.Price * item.Quantity
                };
                order.OrderItems.Add(itemOrdered);
                order.TotalOrder += itemOrdered.Price;
            }

            _context.SaveChanges();  // Save changes to add order items and update order TotalOrder
       
        }
    }
}
