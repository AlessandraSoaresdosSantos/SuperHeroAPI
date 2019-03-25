using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperHeroAPI.EntityFramework
{
    public class AuditEventsMoq: IAuditEventsMoq
    {
        public AuditEventsMoq()
        { }

        public AuditEvent RetornaAuditEventById(int id)
        {
            IEnumerable<AuditEvent> auditEvents = CargaAuditEvents();

            AuditEvent _auditEvent = (from a in auditEvents
                                      where a.Id == id
                                      select a).FirstOrDefault();

            return _auditEvent;
        }

        public IList<AuditEvent> RetornaAuditEvents()
        {
            return CargaAuditEvents().ToList();
        }

        public string Insert(AuditEvent auditEvent)
        {

            var carga = CargaAuditEvents();

            var query = carga.Where(x => x.Id == auditEvent.Id).FirstOrDefault();

            if (query != null)
            {
                return "Valor já cadastrado";
            }
            else
            {
                return "Cadastrado realizado com sucesso";
            }
        }

        public string Update(AuditEvent auditEvent)
        {

            var carga = CargaAuditEvents();

            var query = carga.Where(x => x.Id == auditEvent.Id).FirstOrDefault();

            if (query != null)
            {
                return "Atualização realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        public string Delete(int id)
        {

            var carga = CargaAuditEvents();

            var query = carga.Where(x => x.Id == id).FirstOrDefault();

            if (query != null)
            {
                return "Exclusão realizada com sucesso";
            }
            else
            {
                return "Valor não encontrado na base de dados";
            }
        }

        private IEnumerable<AuditEvent> CargaAuditEvents()
        {
            List<AuditEvent> AuditEvents = new List<AuditEvent>
            {
                new AuditEvent()
                {
                    Id = 1,
                    Entity = "SuperHero",
                    EntityId = 1,
                    Datetime = Convert.ToDateTime("24-03-2019"),
                    Action = "Get",
                    Username_Id = 1
                },

                new AuditEvent()
                {
                    Id = 2,
                    Entity = "SuperPower",
                    EntityId = 1,
                    Datetime = Convert.ToDateTime("24-03-2019"),
                    Action = "Post",
                    Username_Id = 2
                }
            };

            return AuditEvents;
        }
    }
}