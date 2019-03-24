using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{
    [AuthorizeEnum(RolesEnum.Roles.Admin)]
    public class ProtectionAreaController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private IProtectionAreaServices ProtectionAreasServices;
        private readonly SuperHeroAPIContext context;

        public ProtectionAreaController()
        {
            context = new SuperHeroAPIContext();
            ProtectionAreasServices = new ProtectionAreaServices(context);
        }
        #endregion

        #region Métodos

        // GET api/ProtectionArea
        [ResponseType(typeof(List<ProtectionArea>))]
        [System.Web.Http.HttpGet]
        [Route("api/protectionarea")]
        public IEnumerable<ProtectionArea> Get()
        {
            try
            {
                return ProtectionAreasServices.GetAll().ToList();
            }
            catch
            {
                return null;
            }
        }

        // GET: api/ProtectionArea/Get/5
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpGet]
        [Route("api/protectionarea/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ProtectionAreasServices.Get(id));
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // POST: api/ProtectionArea/Post
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpPost]
        [Route("api/protectionarea")]
        public IHttpActionResult Post(ProtectionArea protectionArea)
        {
            try
            {
                var _protectionArea = ProtectionAreasServices.Create(protectionArea);
                new Auditing(System.Web.HttpContext.Current, _protectionArea.Id).RegisterAuditing();

                return Ok(protectionArea);
            }
            catch
            {
                return Ok("Erro ao cadastrar a ProtectionArea");
            }
        }

        // PUT: api/ProtectionArea/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/protectionarea")]
        public IHttpActionResult Put(int id, [FromBody]ProtectionArea protectionArea)
        {
            try
            {
                protectionArea.Id = id;
                var _protectionArea = ProtectionAreasServices.Update(protectionArea);
                new Auditing(System.Web.HttpContext.Current, _protectionArea.Id).RegisterAuditing();

                return Ok(_protectionArea);
            }
            catch {
                return Ok("Erro ao atualizar a ProtectionArea");
            }
        }

        // DELETE: api/ProtectionArea/Delete/5
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpDelete]
        [Route("api/protectionarea/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try {
                var _protectionArea = ProtectionAreasServices.Remove(id);
                new Auditing(System.Web.HttpContext.Current, _protectionArea.Id).RegisterAuditing();

                return Ok(_protectionArea);
            }
            catch {
                return Ok("Erro ao excluir a ProtectionArea");
            }
        }

        #endregion
    }
}