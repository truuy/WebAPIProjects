using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Set up the dbContext
        private readonly ExpenseTrackerContext expenseTrackerContext;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(Guid userId)
        {
            var user = _userService.GetUserById(userId);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("createuser")]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.CreateUser(userDTO);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create user: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            // Call the authentication service to verify credentials
            bool isAuthenticated = _authenticationService.Login(loginDTO);

            if (isAuthenticated)
            {
                // Return success response if authentication is successful
                return Ok(new { message = "Login successful" });
            }
            else
            {
                // Return unauthorized response if authentication fails
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
    }
}
