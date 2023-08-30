using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;
using LaBook_Planet.Data.Entities;
using LaBook_Planet.ViewModels;
using LaBook_Planet.Library.Core.Services.Interfaces;

namespace LaBook_Planet.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, IAccountService accountService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _accountService = accountService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =  await _accountService.RegisterAsync(model);
                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
          
            return View(model); 
        }



        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            if (_accountService.IsLoggedInAsync(User))
                return RedirectToAction("Index", "Home");

            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (_accountService.IsLoggedInAsync(User))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _accountService.LoginAsync(user, model.Password))
                    {
                        if(string.IsNullOrEmpty(ReturnUrl))
                            return RedirectToAction("Index", "Home");
                        else
                            return LocalRedirect(ReturnUrl);
                    }
                }
            }
            //ModelState.AddModelError("Invalid credentials", "Unsuccessful Login");
            ViewBag.Err = "Invalid credentials";

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (_accountService.IsLoggedInAsync(User))
                return RedirectToAction("Indec", "Home");
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}