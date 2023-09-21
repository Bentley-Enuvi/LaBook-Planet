﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaBook_Planet.API.Controllers
{
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Invalid role name provided! Role name must not be empty!");

            var identityRole = new IdentityRole { Name = roleName };
            var roleResult = await _roleManager.CreateAsync(identityRole);

            if (roleResult.Succeeded)
            {
                return Ok("New role added.");
            }

            var errList = new List<string>();
            foreach(var err in roleResult.Errors)
            {
                errList.Add(err.Description);
            }

            return BadRequest(errList);
        }
    }
}
