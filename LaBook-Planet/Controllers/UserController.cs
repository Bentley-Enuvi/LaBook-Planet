﻿using AutoMapper;
using BookStore.ViewModels;
using LaBook_Planet.Data.Entities;
using LaBook_Planet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaBook_Planet.Controllers
{
    [Route("[controller")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);

                var identityResult = await _userManager.CreateAsync(user, model.Password);
                if (identityResult.Succeeded)
                {
                    var result = await _userManager.AddToRoleAsync(user, "regular");
                    if (!result.Succeeded)
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError(err.Code, err.Description);
                        }
                        return BadRequest(ModelState);
                    }

                    var userToReturn = _mapper.Map<ReturnUserViewModel>(user);

                    return Ok(userToReturn);
                }

                foreach (var err in identityResult.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
            }
            return BadRequest(ModelState);
        }


        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var users = _userManager.Users.ToList();
            var usersToReturn = new List<ReturnUserViewModel>();
            if (users.Any())
            {
                foreach (var user in users)
                {
                    usersToReturn.Add(_mapper.Map<ReturnUserViewModel>(user));
                }
            }

            return Ok(usersToReturn);
        }


        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var userToReturn = _mapper.Map<ReturnUserViewModel>(user);

                return Ok(userToReturn);
            }

            return NotFound($"No user was found with id: {id}");
        }


        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRole([FromBody] AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                    return NotFound($"Could not find user with id: {model.UserId}");

                var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                if (!result.Succeeded)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);
                    }
                }

                return Ok("Role added t user");
            }
            return BadRequest(ModelState);
        }


        [HttpPost("get-user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound($"Could not find user wit id: {userId}");

            var userRoles = await _userManager.GetRolesAsync(user);

            return Ok(userRoles);
        }
        
    }
}
