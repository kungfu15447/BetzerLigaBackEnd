using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetzerLiga.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundsController : ControllerBase
    {
        private IRoundService _roundService;

        public RoundsController(IRoundService roundService)
        {
            _roundService = roundService;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public ActionResult<List<Round>> Get([FromQuery]string tournament, int userId)
        {
            try 
            {
                if (tournament == "tour")
                {
                    var list = new List<Round>() { _roundService.GetCurrentRoundFromTournament() };
                    return Ok(list);
                }
                else if((tournament == "matches") && (userId > 0))
                {
                    var list = new List<Round>() { _roundService.GetMatchesByCurrentRoundAndByUserId(userId) };
                    return Ok(list);
                }
                else
                {
                    return Ok(_roundService.ReadAll());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }

        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Round> Get(int id)
        {
            return _roundService.ReadById(id);
        }

        // POST api/values
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Round> Post([FromBody] Round round)
        {
            return _roundService.Create(round);
        }

        // PUT api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Round> Put(int id, [FromBody] Round round)
        {
            if (id < 1 || id != round.Id) 
            {
                return BadRequest("The id in query and id from body is not the same");
            }
            else
            {
                return Ok(_roundService.Update(round));
            }
        }

        // DELETE api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Round> Delete(int id)
        {
            return  _roundService.Delete(id);
        }
    }
}