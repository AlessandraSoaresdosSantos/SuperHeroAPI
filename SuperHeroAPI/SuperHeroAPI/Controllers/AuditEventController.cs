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
            return AuditEventServices.GetAll().ToList();
        }

        /// <summary>
        /// Return AuditEventbyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: AuditEvent/Get/5
        [ResponseType(typeof(AuditEvent))]
        [System.Web.Http.HttpGet]
        [Route("api/auditevent/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(AuditEventServices.Get(id));
        }

        // POST: AuditEvent/Post
        [ResponseType(typeof(AuditEvent))]
        [System.Web.Http.HttpPost]
        [Route("api/auditevent")]
        public IHttpActionResult Post(AuditEvent collection)
        {
            return Ok(AuditEventServices.Create(collection));
        }

        // GET: AuditEvent/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/auditevent")]
        public IHttpActionResult Put([FromBody]AuditEvent auditEvent)
        {
            return Ok(AuditEventServices.Update(auditEvent));
        }

        // POST: AuditEvent/Delete/5
        [System.Web.Http.HttpDelete]
        [Route("api/auditevent/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(AuditEventServices.Remove(id));
        }

        #endregion
    }
}
