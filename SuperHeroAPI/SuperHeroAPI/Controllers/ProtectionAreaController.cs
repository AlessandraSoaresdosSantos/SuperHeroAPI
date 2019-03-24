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
            return ProtectionAreasServices.GetAll().ToList();
        }

        /// <summary>
        /// Return ProtectionAreabyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ProtectionArea/Get/5
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpGet]
        [Route("api/protectionarea/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(ProtectionAreasServices.Get(id));
        }

        // POST: api/ProtectionArea/Post
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpPost]
        [Route("api/protectionarea")]
        public IHttpActionResult Post(ProtectionArea collection)
        {
            return Ok(ProtectionAreasServices.Create(collection));
        }

        // PUT: api/ProtectionArea/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/protectionarea")]
        public IHttpActionResult Put(int id, [FromBody]ProtectionArea protectionArea)
        {
            protectionArea.Id = id;
              
            return Ok(ProtectionAreasServices.Update(protectionArea));
        }

        // DELETE: api/ProtectionArea/Delete/5
        [ResponseType(typeof(ProtectionArea))]
        [System.Web.Http.HttpDelete]
        [Route("api/protectionarea/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(ProtectionAreasServices.Remove(id));
        }

        #endregion
    }
}