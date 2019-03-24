using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{
    
    public class SuperPowerController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private ISuperPowerServices SuperPowersServices;
        private readonly SuperHeroAPIContext context;

        public SuperPowerController()
        {
            context = new SuperHeroAPIContext();
            SuperPowersServices = new SuperPowerServices(context);
        }
        #endregion

        #region Métodos

        // GET api/superpower
      //  [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(List<SuperPower>))]
        [System.Web.Http.HttpGet]
        [Route("api/superpower")]
        public IEnumerable<SuperPower> Get()
        {
            return SuperPowersServices.GetAll().ToList();
        }

      //  [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpGet]
        [Route("api/superpower/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(SuperPowersServices.Get(id));
        }

        // POST: SuperPower/Post
      //  [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpPost]
        [Route("api/superpower")]
        public IHttpActionResult Post(SuperPower collection)
        {
            return Ok(SuperPowersServices.Create(collection));
        }

        // GET: SuperPower/Put/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/superpower")]
        public IHttpActionResult Put(int id, [FromBody]SuperPower superPower)
        {
            superPower.Id = id;

            return Ok(SuperPowersServices.Update(superPower));
        }

        // POST: SuperPower/Delete/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpDelete]
        [Route("api/superpower/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            bool superPowerComSuperHero = new SuperPowerValidation().SuperPowerComSuperHero(id);
            if (superPowerComSuperHero)
            {
                return Ok(SuperPowersServices.Remove(id));
            }
            else {
                return Ok($"Não é possível excluir porque o SuperPower id{id} , possui associação com SuperHero.");
            }
            
        }

        #endregion
    }
}