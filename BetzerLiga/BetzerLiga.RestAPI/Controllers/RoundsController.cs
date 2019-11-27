using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.Entity;
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
        [HttpGet]
        public ActionResult<List<Round>> Get()
        {
            return _roundService.ReadAll();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Round> Get(int id)
        {
            return _roundService.ReadById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Round> Post([FromBody] Round round)
        {
            return _roundService.Create(round);
        }

        // PUT api/values/5
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
        [HttpDelete("{id}")]
        public ActionResult<Round> Delete(int id)
        {
            return  _roundService.Delete(id);
        }
    }
}