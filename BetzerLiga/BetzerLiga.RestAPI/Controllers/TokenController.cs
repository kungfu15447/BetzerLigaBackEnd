using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetzerLiga.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IUserService userService;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IAuthenticationHelper authService, IUserService uService)
        {
            userService = uService;
            authenticationHelper = authService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = userService.GetUserByEmail(model.Username);

            if(user == null)
            {
                return Unauthorized();
            }
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized();
            }
            user.PasswordSalt = user.PasswordHash = null;
            return Ok(new
            {
                User = user,
                token = authenticationHelper.GenerateToken(user)
            });
        }
        
    }
}