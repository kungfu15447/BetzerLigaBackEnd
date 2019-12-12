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
        [HttpPost]
        public void Post([FromBody] List<UserMatch> userMatches)
        {
            _umService.Create(userMatches);
        }
    }
}