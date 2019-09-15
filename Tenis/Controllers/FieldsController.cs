using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenis.Models;
using Tenis.Services.Interface;
using Tenis.ViewModels.Field;

namespace Tenis.Controllers
{
    [Route("api/fields")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private IFieldsService fieldsService;
        private IUsersService userService;

        public FieldsController (IFieldsService fieldsService, IUsersService userService)
        {
            this.fieldsService = fieldsService;
            this.userService = userService;
        }

        private User GetConectedUser()
        {
            return userService.GetCurrentUser(HttpContext);
        }

        [Authorize(Roles = "UserManager, Admin")]
        [HttpPost("create")]
        public IActionResult Create([FromBody]FieldPostModel fieldPostModel)
        {
            var field = fieldsService.Create(fieldPostModel);
            if (field == null)
            {
                return BadRequest(new { ErrorMessage = "NameId and FieldNumber already exists." });
            }
            return Ok(field);
        }

        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var fields = fieldsService.GetAll();
            return Ok(fields);
        }

        [Authorize(Roles = "UserManager, Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var fields = fieldsService.DeleteField(id);
            if (fields == null)
            {
                return BadRequest();
            }

            return Ok(fields);
        }

        [Authorize(Roles = "Regular, UserManager, Admin")]
        [HttpGet("search")]
        public IActionResult GetByName(string name)
        {
            var fields = fieldsService.GetByName(name);
            if (name == null)
            {
                return GetAll();
            }
            if (fields == null)
            {
                return GetAll();
            }

            return Ok(fields);
        }

        [Authorize(Roles = "UserManager, Admin")]
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] FieldPostModel fieldPost)
        {
            var field = fieldsService.Upsert(id, FieldPostModel.ToFields(fieldPost));

            if (field == null)
            {
                return BadRequest();
            }

            return Ok(field);
        }
    }
}