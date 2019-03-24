using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace SuperHeroAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
 
            // Rotas da API da Web
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
