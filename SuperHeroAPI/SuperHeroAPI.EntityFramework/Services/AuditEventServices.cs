using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class AuditEventServices : BaseServices, IAuditEventServices
    {
         
        public AuditEventServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
   
        }

        public AuditEvent Get(int id)
        {
            return UnityOfWork.AuditEventRepository.Get(r => r.Id == id);
        }

        public List<AuditEvent> GetAll()
        {
            return UnityOfWork.AuditEventRepository.GetAll();
        }

        public AuditEvent Create(AuditEvent auditEvent)
        {
            UnityOfWork.AuditEventRepository.Add(auditEvent);

            UnityOfWork.SaveAllChanges();

            return auditEvent;
        }

        public AuditEvent Update(AuditEvent auditEvent)
        {
            var dbAuditEvent = UnityOfWork.AuditEventRepository.Update(auditEvent);

            UnityOfWork.SaveAllChanges();

            return dbAuditEvent;
        }

        public AuditEvent Remove(int id)
        {
            var auditEvent = UnityOfWork.AuditEventRepository.Get(r => r.Id == id);

            if (auditEvent != null)
            {
                var dbAuditEvent = UnityOfWork.AuditEventRepository.Remove(auditEvent);

                UnityOfWork.SaveAllChanges();

                return dbAuditEvent;
            }

            return null;
        }

    }
}