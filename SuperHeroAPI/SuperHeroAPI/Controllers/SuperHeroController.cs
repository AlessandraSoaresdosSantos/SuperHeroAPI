using SuperHeroAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SuperHeroAPI.Controllers
{

    public class SuperHeroController : ApiController
    {
        #region Declaração e inicialização de variáveis 

        private ISuperHeroServices SuperHerosServices;
        private readonly SuperHeroAPIContext context;

        public SuperHeroController()
        {
            context = new SuperHeroAPIContext();
            SuperHerosServices = new SuperHeroServices(context);
        }
        #endregion

        #region Métodos

        // GET api/SuperHero
        [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(List<SuperHero>))]
        [System.Web.Http.HttpGet]
        [Route("api/superhero")]
        public IEnumerable<SuperHero> Get()
        {
            try
            {
                return SuperHerosServices.GetAll().ToList();
            }
            catch
            {
                return null;
            }
        }

        // GET: api/SuperHero/GetArea/1/2
        [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(List<SuperHero>))]
        [System.Web.Http.HttpGet]
        [Route("api/superhero/{latitude}/{longitude}")]
        public IHttpActionResult GetArea([FromUri]string latitude, [FromUri]string longitude)
        {
            try
            {
                float _latitude = float.Parse(latitude);
                float _longitude = float.Parse(longitude);

                List<ProtectionArea> protectionAreas = new ProtectionAreaServices(context).GetRadiusSuperHero(_latitude, _longitude);

                if (protectionAreas != null)
                {
                    var _superHero = SuperHerosServices.GetAllByRadius(protectionAreas.Select(_ => _.Id).ToList());

                    return Ok(_superHero);
                }
                return Ok(NotFound());

            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // GET: SuperHero/Get/5
        [AuthorizeEnum(RolesEnum.Roles.Admin, RolesEnum.Roles.Standard)]
        [ResponseType(typeof(SuperHero))]
        [System.Web.Http.HttpGet]
        [Route("api/superhero/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(SuperHerosServices.Get(id));
            }
            catch
            {
                return Ok(NotFound());
            }
        }

        // POST: SuperHero/Post
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperHero))]
        [System.Web.Http.HttpPost]
        [Route("api/superhero")]
        public IHttpActionResult Post(SuperHero superHero)
        {
            try
            {

                var _superHero = SuperHerosServices.Create(superHero);
                new Auditing(System.Web.HttpContext.Current, _superHero.Id).RegisterAuditing();
                return Ok(_superHero);
            }
            catch
            {
                return Ok("Erro ao cadastrar o SuperHero");
            }
        }

        // GET: SuperHero/Put/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(void))]
        [System.Web.Http.HttpPut]
        [Route("api/superhero")]
        public IHttpActionResult Put(int id, [FromBody]SuperHero superHero)
        {
            try
            {
                superHero.Id = id;
                var _superHero = SuperHerosServices.Update(superHero);
                new Auditing(System.Web.HttpContext.Current, _superHero.Id).RegisterAuditing();

                return Ok(_superHero);
            }
            catch
            {
                return Ok("Erro ao atualizar o SuperHero");
            }
        }

        // POST: SuperHero/Delete/5
        [AuthorizeEnum(RolesEnum.Roles.Admin)]
        [ResponseType(typeof(SuperHero))]
        [System.Web.Http.HttpDelete]
        [Route("api/superhero/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var _superHero = SuperHerosServices.Remove(id);
                new Auditing(System.Web.HttpContext.Current, _superHero.Id).RegisterAuditing();

                return Ok(_superHero);
            }
            catch
            {
                return Ok("Erro ao excluir o SuperHero");
            }
        }

        #endregion
    }
}