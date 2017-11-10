using System;
using System.Net;
using System.Web;
using System.Web.Http;
using NorrisTrip.Domain.Domain.Entity;
using NorrisTrip.Domain.Infra.Messages;

namespace NorrisTrip.Collector.Web.Controllers
{
    [RoutePrefix("collector")]
    public class CollectorController : ApiController
    {
        private readonly IMessageQueue _messageQueue;

        public CollectorController(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }


        [Route("behavior")]
        public IHttpActionResult Post(BehaviorData behavior)
        {
            behavior.Created = DateTime.Now.ToUniversalTime();
            behavior.IP = HttpContext.Current.Request.UserHostAddress;
            behavior.UserAgent = HttpContext.Current.Request.UserAgent;
            behavior.Referrer = behavior.Referrer ?? (HttpContext.Current.Request.UrlReferrer != null ? HttpContext.Current.Request.UrlReferrer.AbsoluteUri : String.Empty);
            _messageQueue.Publish(behavior);

            return this.StatusCode(HttpStatusCode.Created);

        }
    }
}
