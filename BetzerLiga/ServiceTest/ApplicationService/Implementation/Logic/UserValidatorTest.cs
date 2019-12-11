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

        [Fact]
        public void TestThrowsExceptionIfLastnameOnUserIsEmpty()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "Frederik",
                Lastname = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfFirstnameOnUserIsEmpty()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "",
                Lastname = "Jensen"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfEmailOnUserIsEmpty()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "Bob",
                Lastname = "Jensen",
                Email = ""
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("An users Email cannot be empty", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfUserIsNull()
        {
            UserValidator userVali = new UserValidator();
            User user = null;
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.CheckIfUserIsNull(user));
            Assert.Equal("Could not find user/user does not exist", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfNameOnUserConatinsNumbers()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "Bob57",
                Lastname = "Jensen56",
                Email = "fhj@test.dk"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot contain numbers", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfFirstnameOnUserConatinsNumbers()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "Bob57",
                Lastname = "Jensen",
                Email = "fhj@test.dk"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot contain numbers", ex.Message);
        }

        [Fact]
        public void TestThrowsExceptionIfLastnameOnUserConatinsNumbers()
        {
            UserValidator userVali = new UserValidator();
            User user = new User()
            {
                Firstname = "Bob",
                Lastname = "Jensen56",
                Email = "fhj@test.dk"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
            userVali.ValidateUser(user));
            Assert.Equal("A users firstname and/or lastname cannot contain numbers", ex.Message);
        }
    }
}
