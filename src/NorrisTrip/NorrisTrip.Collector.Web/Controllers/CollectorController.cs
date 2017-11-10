using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NorrisTrip.Collector.Web.Domain.Entity;
using NorrisTrip.Collector.Web.Domain.Repository;

namespace NorrisTrip.Collector.Web.Controllers
{
    [RoutePrefix("collector")]
    public class CollectorController : ApiController
    {
        private readonly IBehaviorRepository _repository;

        public CollectorController(IBehaviorRepository repository)
        {
            _repository = repository;
        }


        [Route("behavior")]
        public IHttpActionResult Post(BehaviorData behavior)
        {
            behavior.Created = DateTime.Now.ToUniversalTime();
            behavior.IP = HttpContext.Current.Request.UserHostAddress;
            behavior.UserAgent = HttpContext.Current.Request.UserAgent;
            behavior.Referrer = behavior.Referrer ?? (HttpContext.Current.Request.UrlReferrer != null ? HttpContext.Current.Request.UrlReferrer.AbsoluteUri : String.Empty);
            _repository.Create(behavior);

            return this.StatusCode(HttpStatusCode.Created);

        }
    }
}
