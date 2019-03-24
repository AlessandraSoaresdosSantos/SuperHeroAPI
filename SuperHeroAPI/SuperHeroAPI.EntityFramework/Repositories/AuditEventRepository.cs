using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class AuditEventRepository : RepositoryBase<AuditEvent>, IAuditEventRepository
    {
        public AuditEventRepository(SuperHeroAPIContext Db) : base(Db)
        {
        }
    }
}