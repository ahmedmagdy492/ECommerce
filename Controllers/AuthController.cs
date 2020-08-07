using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repository;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public AuthController(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("you have: " + ModelState.ErrorCount + " errors");

            var user = await _userRepository.GetUserByEmail(model.Email);
            if(user == null)
            {
                user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Location = model.Location
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result == IdentityResult.Success)
                {
                    return Created("User has been created successfully", user);
                }
            }
            return BadRequest("Email is already taken");
        }
    }
}
