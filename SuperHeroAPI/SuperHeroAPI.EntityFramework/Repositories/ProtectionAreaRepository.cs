using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class ProtectionAreaRepository : RepositoryBase<ProtectionArea>, IProtectionAreaRepository
    {
        public ProtectionAreaRepository(SuperHeroAPIContext Db) : base(Db)
        {
        }
    }
}