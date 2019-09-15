using Tenis.Models;
using Tenis.Services;
using Tenis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis.Services.Interface;

namespace Tenis.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }

        private User GetConectedUser()
        {
            return userService.GetCurrentUser(HttpContext);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginPostModel login)
        {
            var user = userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterPostModel registerModel)
        {
            var user = userService.Register(registerModel);
            if (user == null)
            {
                return BadRequest(new { ErrorMessage = "Username already exists." });
            }
            return Ok(user);
        }


        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            if (GetConectedUser().UserRole.Equals(null))
            {
                return BadRequest(new { ErrorMessage = "You need to be registered to see players!" });
            }
            var users = userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = "UserManager, Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var user = userService.DeleteUser(id);
            if (user == null)
            {
                return BadRequest();
            }
            
            return Ok(user);
        }

        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] RegisterPostModel registerPostModel)
        {
            var user = userService.UpsertUser(id, RegisterPostModel.ToUser(registerPostModel));

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}