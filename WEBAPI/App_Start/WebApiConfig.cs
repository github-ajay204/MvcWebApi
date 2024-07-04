using System.Web.Http;
using System.Web.Http.Cors;

namespace WEBAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS for specific origins
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;
//using System.Web.Http.Cors;

//namespace WEBAPI
//{
//    public static class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API configuration and services

//            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
//            config.EnableCors(cors);

//            // Other Web API configuration
//            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );


//            // Web API routes
//            //config.MapHttpAttributeRoutes();

//            //config.Routes.MapHttpRoute(
//            //    name: "DefaultApi",
//            //    routeTemplate: "api/{controller}/{id}",
//            //    defaults: new { id = RouteParameter.Optional }
//            //);
//        }
//    }
//}
