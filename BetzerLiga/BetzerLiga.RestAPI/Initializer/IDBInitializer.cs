using BetzerLiga.Infrastructure.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetzerLiga.RestAPI.Initializer
{
    interface IDBInitializer
    {
        void Seed(BetzerLigaContext ctx);
    }
}
