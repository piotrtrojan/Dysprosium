using System.Net;
using System.Web.Http;

namespace Dysprosium.Demo.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldApiController : ApiController
    {
        [Route("helloworld")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(HttpStatusCode.OK, "Hello World from Web Api");
        }
    }
}