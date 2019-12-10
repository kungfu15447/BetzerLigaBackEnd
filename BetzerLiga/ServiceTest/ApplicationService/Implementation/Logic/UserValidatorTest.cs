using BetzerLiga.Core.ApplicationService.Implementation.Logic;
using BetzerLiga.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ServiceTest.ApplicationService.Implementation.Logic
{
    public class UserValidatorTest
    {
        [Fact]
        public void TestThrowsExceptionIfNameOnUserIsEmpty()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "",
                Lastname = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot be empty", ex.Message);
        }
    }
}
