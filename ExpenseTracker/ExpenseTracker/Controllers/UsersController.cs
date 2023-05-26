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

        public UsersController(IUserService userService)
        {
            _userService= userService;
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
    }
}
