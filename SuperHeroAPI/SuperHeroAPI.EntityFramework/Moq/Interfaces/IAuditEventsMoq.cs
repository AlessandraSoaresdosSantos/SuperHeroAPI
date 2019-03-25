using System.Collections.Generic;

namespace SuperHeroAPI.EntityFramework
{
    public interface IAuditEventsMoq
    {

        AuditEvent RetornaAuditEventById(int id);
        IList<AuditEvent> RetornaAuditEvents();
        string Insert(AuditEvent auditEvent);
        string Update(AuditEvent auditEvent);
        string Delete(int id);
    }
}
