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
        [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(List<SuperPower>))]
        [System.Web.Http.HttpGet]
        [Route("api/superpower")]
        public IEnumerable<SuperPower> Get()
        {
            try
            {
                return SuperPowersServices.GetAll().ToList();
            }
            catch
            {
                return null;
            }
        }

        [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpGet]
        [Route("api/superpower/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(SuperPowersServices.Get(id));
            }
            catch
            {
                return null;
            }
        }

        // POST: SuperPower/Post
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpPost]
        [Route("api/superpower")]
        public IHttpActionResult Post(SuperPower superPower)
        {
            try
            {
                var _superPower = SuperPowersServices.Create(superPower);
                new Auditing(System.Web.HttpContext.Current, _superPower.Id).RegisterAuditing();
                return Ok(_superPower);
            }
            catch
            {
                return Ok("Erro ao incluir o SuperPower");
            }
        }

        // GET: SuperPower/Put/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/superpower")]
        public IHttpActionResult Put(int id, [FromBody]SuperPower superPower)
        {
            try
            {
                superPower.Id = id;
                var _superPower = SuperPowersServices.Update(superPower);
                new Auditing(System.Web.HttpContext.Current, _superPower.Id).RegisterAuditing();

                return Ok(_superPower);
            }
            catch
            {
                return Ok("Erro ao atualizar o SuperPower");
            }
        }

        // POST: SuperPower/Delete/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperPower))]
        [System.Web.Http.HttpDelete]
        [Route("api/superpower/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try {
                bool superPowerComSuperHero = new SuperPowerValidation().SuperPowerComSuperHero(id);
                if (superPowerComSuperHero)
                {
                    var _superPower = SuperPowersServices.Remove(id);
                    new Auditing(System.Web.HttpContext.Current, _superPower.Id).RegisterAuditing();

                    return Ok(_superPower);
                }
                else
                {
                    return Ok($"Não é possível excluir porque o SuperPower id{id} , possui associação com SuperHero.");
                }
            }
            catch {
                return Ok("Erro ao excluir o SuperPower");
            }
        }

        #endregion
    }
}