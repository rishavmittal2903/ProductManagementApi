using ProductManagement.Interfaces;
using ProductManagement.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductManagement
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new Container();
            container.Register<IDBContext, SqlDBContext>(Lifestyle.Singleton);
            container.Register<IMailActions, GmailHandler>();
            container.Verify();
            
            DependencyResolver.SetResolver(new DependencyResolverHandler(container));
            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolverHandler(container);
        }
    }
}
