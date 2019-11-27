using BetzerLiga.Infrastructure.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServiceTest
{
    public class AuthenticationServiceTest
    {
        AuthenticationHelper authHelp;

        [Fact]
        public void TestCreatePasswordHash()
        {
           // Byte[] passwordHashUser, passwordSaltUser;

           // Assert.Equal(authHelp.CreatePasswordHash("password", out passwordSaltUser, out passwordHashUser), );
        }

        [Fact]
        public void TestVerifyPasswordHash()
        {

        }

        [Fact]
        public void TestGenerateToken()
        {

        }


    }
}
