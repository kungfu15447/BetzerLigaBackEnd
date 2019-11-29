using System;
using System.Collections.Generic;
using System.Text;

namespace BetzerLiga.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<UserTour> Tournaments { get; set; }
        public List<UserMatch> Tips { get; set; }
        public List<UserRound> RoundPoints { get; set; }
        public List<User> Following { get; set; }
    }
}
