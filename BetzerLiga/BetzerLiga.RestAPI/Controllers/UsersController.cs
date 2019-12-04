using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetzerLiga.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userServ;
        public UsersController(IUserService userService)
        {
            _userServ = userService;
        }

        // GET api/users
        //[Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var users = _userServ.GetAll();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/users/5
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 1");
            return Ok(_userServ.GetUserById(id));
        }

        // POST api/users

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return Ok(_userServ.Add(user));
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (id < 1 || id != user.Id)
            {
                return BadRequest("Parameter id and user id must be the same");
            }
            User testUser = _userServ.Update(user);
            
            return Ok();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = _userServ.Delete(id);
            if(user == null)
            {
                return StatusCode(404, $"Did not find the user with the id: {id}");
            }
            return Ok($"User with the id: {id} has been deleted");
        }
    }
}