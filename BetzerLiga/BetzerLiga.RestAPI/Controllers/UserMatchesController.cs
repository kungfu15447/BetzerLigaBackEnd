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
    public class UserMatchesController : ControllerBase
    {
        private IUserMatchService _umService;

        public UserMatchesController(IUserMatchService umService)
        {
            _umService = umService;
        }

        [HttpGet]
        public ActionResult<List<UserMatch>> Get([FromQuery]int userId, int roundId)
        {
            if (userId > 0 && roundId > 0)
            {
                return _umService.GetAllUserMatchesForUserAndRound(userId, roundId);
            }
            else
            {
                return BadRequest("userId or roundId isn't right'");
            }

        }
        [HttpPost]
        public void Post([FromBody] List<UserMatch> userMatches)
        {
            _umService.Create(userMatches);
        }

        [HttpPut]
        public ActionResult<List<UserMatch>> Put([FromBody] List<UserMatch> tipsToUpdate)
        {
            _umService.UpdateUserMatches(tipsToUpdate);
            return tipsToUpdate;
        }
    }
}