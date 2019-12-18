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
        [Authorize]
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
                return StatusCode(500, e.StackTrace);
            }
        }

        // GET api/users/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                if (id < 1) return BadRequest("Id must be greater than 1");
                return Ok(_userServ.GetUserById(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/users
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                return Ok(_userServ.Add(user));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT api/users/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            try
            {
                if (id < 1 || id != user.Id)
                {
                    return BadRequest("Parameter id and user id must be the same");
                }
                return Ok(_userServ.Update(user));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
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