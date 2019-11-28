using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IUserRepository userRepository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IUserRepository repos, IAuthenticationHelper authService)
        {
            userRepository = repos;
            authenticationHelper = authService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Email == model.Username);

            if(user == null)
            {
                return Unauthorized();
            }
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized();
            }
            return Ok(new
            {
                Username = user.Email,
                token = authenticationHelper.GenerateToken(user)
            });
        }
        
    }
}