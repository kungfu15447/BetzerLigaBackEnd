using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.Entity;
using BetzerLiga.Infrastructure.SQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetzerLiga.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private IMatchService _matchService;
        private BetzerLigaContext _context;
        public MatchesController(IMatchService matchService, BetzerLigaContext context)
        {
            _matchService = matchService;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Match>> Get()
        {
            return Ok(_matchService.GetAllMatches());
        }

        [HttpGet("{id}")]
        public ActionResult<Match> Get(int id)
        {
            return Ok(_matchService.GetMatchById(id));
        }

        // POST api/pet
        [HttpPost]
        public ActionResult<IEnumerable<Match>> Post([FromBody] List<Match> matches)
        {
            return Ok(_matchService.CreateMatch(matches));
        }

        // PUT api/pet/5
        [HttpPut("{id}")]
        public ActionResult<Tournament> Put(int id, [FromBody] Match match)
        {
            if (id == match.Id)
            {
                return Ok(_matchService.UpdateMatch(match));
            }
            else
            {
                return BadRequest("Id does not match id of the Match");
            }
            
        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public ActionResult<Tournament> Delete(int id)
        {
            Match match = _matchService.GetMatchById(id);
            if (match != null)
            {
                return Ok(_matchService.DeleteMatch(match));
            }else
            {
                return NotFound("Could not find match to delete");
            }
            
        }
    }
}