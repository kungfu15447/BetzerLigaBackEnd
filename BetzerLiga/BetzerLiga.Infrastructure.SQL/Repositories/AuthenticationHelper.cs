using System;
using System.Collections.Generic;
using System.Text;
using BetzerLiga.Core.Entity;

namespace BetzerLiga.Core.ApplicationService.Authentication
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private byte[] secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            secretBytes = secret;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            throw new NotImplementedException();
        }
    }
}
