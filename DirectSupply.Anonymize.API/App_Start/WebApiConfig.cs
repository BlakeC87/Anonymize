using DirectSupply.Anonymize.API.Areas.HelpPage;
using System.Web;
using System.Web.Http;

namespace DirectSupply.Anonymize.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Documentation
            config.SetDocumentationProvider(
                new XmlDocumentationProvider(
                    HttpContext.Current.Server.MapPath("~/App_Data/DirectSupply.Anonymize.API.xml")));
        }
    }
}
