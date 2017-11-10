using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;

namespace NorrisTrip.Collector.Web.Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };

            config.MapHttpAttributeRoutes();
        }
    }
}