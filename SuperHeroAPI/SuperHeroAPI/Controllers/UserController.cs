using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{

    //  [AuthorizeEnum(RolesEnum.Roles.Admin)]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private IUsersServices UsersServices;
        private readonly SuperHeroAPIContext context;

        public UserController()
        {
            context  = new SuperHeroAPIContext(); 
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
            return Ok(UsersServices.GetAll());
        }

        /// <summary>
        /// Return UserbyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: User/Get/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpGet] 
        public IHttpActionResult Get(int id)
        {
            var user = UsersServices.Get(id);
            new Auditing(System.Web.HttpContext.Current, id).RegisterAuditing(); 
            //COLOCAR AS EXPECTIONS
            return Ok(user);
        }

        // POST: User/Post
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpPost]
        [Route("api/user")]
        public IHttpActionResult Post([FromBody]User collection)
        {
            return Ok(UsersServices.Create(collection));
        }

        // GET: User/Put/5
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/user")]
        public IHttpActionResult Put(int id, [FromBody]User user  )
        {
            user.Id = id;

            return Ok(UsersServices.Update(user));
        }

        // POST: User/Delete/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpDelete]
        [Route("api/user/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(UsersServices.Remove(id));
        }

        #endregion
    }
}
