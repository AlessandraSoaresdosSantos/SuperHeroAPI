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
            try
            {
                return RolesServices.GetAll().ToList();
            }
            catch
            {
                return null;
            }
        }

        // GET: Role/Get/5
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpGet]
        [Route("api/role/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(RolesServices.Get(id));
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // POST: Role/Post
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpPost]
        [Route("api/role")]
        public IHttpActionResult Post(Role role)
        {
            try
            {
                var _role = RolesServices.Create(role);
                new Auditing(System.Web.HttpContext.Current, role.Id).RegisterAuditing();

                return Ok(_role);
            }
            catch
            {
                return Ok("Erro ao cadastrar o Role");
            }
        }

        // GET: Role/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/role")]
        public IHttpActionResult Put(int id, [FromBody]Role role)
        {
            try
            {
                role.Id = id;
                var _role = RolesServices.Update(role);
                new Auditing(System.Web.HttpContext.Current, role.Id).RegisterAuditing();
                return Ok(_role);
            }
            catch
            {
                return Ok("Erro ao atualizar o Role");
            }
        }

        // POST: Role/Delete/5
        [ResponseType(typeof(Role))]
        [System.Web.Http.HttpDelete]
        [Route("api/role/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var _role = RolesServices.Remove(id);
                new Auditing(System.Web.HttpContext.Current, id).RegisterAuditing();

                return Ok(_role);
            }
            catch
            {
                return Ok("Erro ao excluiri o Role");
            }
        }

        #endregion
    }


}