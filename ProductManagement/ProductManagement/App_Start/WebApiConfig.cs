using ProductManagement.Interfaces;
using ProductManagement.Models;
using System.Web.Http;

namespace ProductManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IDBContext dbContext;
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new BuildRequestAndResponse());
            config.Filters.Add(new CustomExceptionHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
