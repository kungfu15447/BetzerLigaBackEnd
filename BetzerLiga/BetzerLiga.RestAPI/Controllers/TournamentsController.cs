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
    public class TournamentsController : ControllerBase
    {
        private ITourService _tourService;

        public TournamentsController(ITourService tourService)
        {
            _tourService = tourService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<List<Tournament>> Get()
        {
            return Ok(_tourService.GetAllTour());
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Tournament> Get(int id)
        {
            try
            {
                return Ok(_tourService.GetTourById(id));
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/pet
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Tournament> Post([FromBody] Tournament tournament)
        {
            try 
            {
                return Ok(_tourService.CreateTournament(tournament));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/pet/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Tournament> Put(int id, [FromBody] Tournament tournament)
        {
            if (id == tournament.Id)
            {
                try
                {
                    return Ok(_tourService.UpdateTournament(tournament));
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }    
            }
            else
            {
                return BadRequest("Id in header does not match Tournaments id");
            }
            
        }

        // DELETE api/pet/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Tournament> Delete(int id)
        {
            try
            {
                Tournament tournament = _tourService.GetTourById(id);
                return Ok(_tourService.DeleteTournament(tournament));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }         
        }
    }
}