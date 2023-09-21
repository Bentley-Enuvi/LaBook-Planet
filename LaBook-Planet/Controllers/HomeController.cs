using LaBook_Planet.Library.Core.Services.Interfaces.External;
using LaBook_Planet.Models;
using LaBook_Planet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaBook_Planet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageService _imageService;

        public HomeController(ILogger<HomeController> logger, IImageService image)
        {
            _logger = logger;
            _imageService = image;
        }


        [HttpGet]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadImageViewModel model)
        {
            var result = await _imageService.UploadImage(model.Image, model.Foldername);
            if(result.ContainsKey("Code") && result["Code"].Equals("200"))
            {
                ViewBag.Success = $"PublicId: {result["PublicId"]}, Url: {result["Url"]}";
                return View();
            }

            ViewBag.Success = $"Error: {result["Message"]}";
            return View();
        }
    }
}