using System.Web.Http;
using NorrisTrip.Collector.Web.Start;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace NorrisTrip.Collector.Web.Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "NorrisTrip.Collector.Web");
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();

                        c.DocExpansion(DocExpansion.List);
                    });
        }
    }
}
