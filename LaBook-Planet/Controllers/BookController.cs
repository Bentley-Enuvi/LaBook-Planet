using LaBook_Planet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaBook_Planet.Controllers
{
    public class BookController : Controller
    {
        public BookController()
        {

        }



        [HttpGet]
        [Authorize(Roles = "admin")]

        public IActionResult AddBook()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
