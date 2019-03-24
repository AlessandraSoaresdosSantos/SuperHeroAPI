using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{
    [AuthorizeEnum(RolesEnum.Roles.Admin)]
    public class RoleController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private IRoleServices RolesServices;
        private readonly SuperHeroAPIContext context;

        public RoleController()
        {
            context = new SuperHeroAPIContext();
            RolesServices = new RoleServices(context);
        }
        #endregion

        #region Métodos

        // GET api/Role
        [ResponseType(typeof(List<Role>))]
        [System.Web.Http.HttpGet]
        [Route("api/role")]
        public IEnumerable<Role> Get()
        {
            return RolesServices.GetAll().ToList();
        }

        // GET: Role/Get/5
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpGet]
        [Route("api/role/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(RolesServices.Get(id));
        }

        // POST: Role/Post
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpPost]
        [Route("api/role")]
        public IHttpActionResult Post(Role collection)
        {
            return Ok(RolesServices.Create(collection));
        }

        // GET: Role/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/role")]
        public IHttpActionResult Put(int id, [FromBody]Role role)
        {
            role.Id = id;

            return Ok(RolesServices.Update(role));
        }

        // POST: Role/Delete/5
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpDelete]
        [Route("api/role/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(RolesServices.Remove(id));
        }

        #endregion
    }
}