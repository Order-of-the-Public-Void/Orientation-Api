using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using Dapper;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [HttpGet, Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var productData = new ProductDataAccess();
                var products = productData.GetAllProducts();

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query didn't work ...");
            }
        }

        [HttpPut, Route("")]
        public HttpResponseMessage Put()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Post()
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage Delete()
        {
            throw new NotImplementedException();
        }
    }
}
