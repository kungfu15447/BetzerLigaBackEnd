﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace BetzerLiga.Infrastructure.SQL.Repositories
{
    public class UserMatchRepository: IUserMatchRepository
    {
        private BetzerLigaContext _ctx;

        public UserMatchRepository(BetzerLigaContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(UserMatch userMatch)
        {
            _ctx.UserMatches.Attach(userMatch).State = EntityState.Added;
            _ctx.SaveChanges();
        }
    }
}