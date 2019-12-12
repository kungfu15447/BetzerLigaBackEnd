﻿using System;
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
    public class TournamentsController : ControllerBase
    {
        private ITourService _tourService;

        public TournamentsController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public ActionResult<List<Tournament>> Get()
        {
            return Ok(_tourService.GetAllTour());
        }

        [HttpGet("{id}")]
        public ActionResult<Tournament> Get(int id)
        {
           
                return Ok(_tourService.GetTourById(id));
            
        }

        // POST api/pet
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
        [HttpDelete("{id}")]
        public ActionResult<Tournament> Delete(int id)
        {
            Tournament tournament = _tourService.GetTourById(id);
            if (tournament != null)
            {
                return Ok(_tourService.DeleteTournament(tournament));
            }else
            {
                return NotFound("Could not find tournament to delete");
            }
            
        }
    }
}