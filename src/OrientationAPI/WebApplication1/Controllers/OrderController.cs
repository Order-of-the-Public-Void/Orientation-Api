using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [HttpGet, Route("unpaid")]
        public HttpResponseMessage GetUnPaid()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("create")]
        public HttpResponseMessage CreateOrder()
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("paid")]
        public HttpResponseMessage MarkPaid()
        {
            throw new NotImplementedException();
        }
    }
}
