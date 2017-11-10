using System;
using System.Web.Http;
using NorrisTrip.Collector.Web.Start;
using System.Web;

namespace NorrisTrip.Collector.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            string allowMethods = null;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (context.Request.HttpMethod == "OPTIONS")
            {
                if (string.IsNullOrEmpty(allowMethods))
                {
                    allowMethods = "GET, POST";
                }

                context.Response.AddHeader("Cache-Control", "no-cache");
                context.Response.AddHeader("Access-Control-Allow-Methods", allowMethods);
                context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, x-requested-with");
                context.Response.AddHeader("Access-Control-Max-Age", "1728000");
                context.Response.End();
            }
        }

    }
}