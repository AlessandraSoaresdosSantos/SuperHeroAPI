using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{
    // [AuthorizeEnum(RolesEnum.Roles.Admin)]
    public class AuditEventController : ApiController
    {

        #region Declaração e inicialização de variáveis 

        private IAuditEventServices AuditEventServices;
        private readonly SuperHeroAPIContext context;
        public AuditEventController()
        {
            context = new SuperHeroAPIContext();
            AuditEventServices = new AuditEventServices(context);
        }
        #endregion

        #region Métodos

        // GET api/AuditEvent
        [ResponseType(typeof(List<AuditEvent>))]
        [System.Web.Http.HttpGet]
        [Route("api/auditevent")]
        public IEnumerable<AuditEvent> Get()
        {
            try
            {
                return AuditEventServices.GetAll().ToList();
            }
            catch
            {
                return null;
            }
        }

        // GET: AuditEvent/Get/5
        [ResponseType(typeof(AuditEvent))]
        [System.Web.Http.HttpGet]
        [Route("api/auditevent/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(AuditEventServices.Get(id));
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // POST: AuditEvent/Post
        [ResponseType(typeof(AuditEvent))]
        [System.Web.Http.HttpPost]
        [Route("api/auditevent")]
        public IHttpActionResult Post(AuditEvent collection)
        {
            try
            {
                return Ok(AuditEventServices.Create(collection));
            }
            catch
            {
                return Ok("Erro ao cadastrar o AuditEvent");
            }
        }

        // GET: AuditEvent/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/auditevent")]
        public IHttpActionResult Put([FromBody]AuditEvent auditEvent)
        {
            try
            {
                return Ok(AuditEventServices.Update(auditEvent));
            }
            catch
            {
                return Ok("Erro atualizar o AuditEvent");
            }
        }

        // POST: AuditEvent/Delete/5
        [System.Web.Http.HttpDelete]
        [Route("api/auditevent/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(AuditEventServices.Remove(id));
            }
            catch
            {
                return Ok("Erro ao excluir o AuditEvent");
            }
        }

        #endregion
    }
}
