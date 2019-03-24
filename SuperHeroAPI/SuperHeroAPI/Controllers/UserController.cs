using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{

    [AuthorizeEnum(RolesEnum.Roles.Admin)]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private IUsersServices UsersServices;
        private readonly SuperHeroAPIContext context;

        public UserController()
        {
            context = new SuperHeroAPIContext();
            UsersServices = new UsersServices(context);
        }
        #endregion

        #region Métodos

        // GET api/user
        [ResponseType(typeof(List<User>))]
        [System.Web.Http.HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(UsersServices.GetAll());
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // GET: User/Get/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(UsersServices.Get(id));
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // POST: User/Post
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpPost]
        [Route("api/user")]
        public IHttpActionResult Post([FromBody]User user)
        {
            try
            {
                var _user = UsersServices.Create(user);
                new Auditing(System.Web.HttpContext.Current, _user.Id).RegisterAuditing();

                return Ok(_user);
            }
            catch
            {
                return Ok("Erro ao cadastrar o usuário");
            }
        }

        // GET: User/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/user")]
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            try
            {
                user.Id = id;
                var _user = UsersServices.Update(user);
                new Auditing(System.Web.HttpContext.Current, id).RegisterAuditing();

                return Ok(_user);
            }
            catch
            {
                return Ok("Erro ao atualizar o usuário");
            }
        }

        // POST: User/Delete/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpDelete]
        [Route("api/user/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var _user = UsersServices.Remove(id);
                new Auditing(System.Web.HttpContext.Current, id).RegisterAuditing();

                return Ok();
            }
            catch
            {
                return Ok("Erro ao excluir o usuário");
            }
        }

        #endregion
    }
}
