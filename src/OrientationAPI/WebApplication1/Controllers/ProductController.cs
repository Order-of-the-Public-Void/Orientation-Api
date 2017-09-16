using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        [HttpPut, Route("outofstock")]
        public HttpResponseMessage MarkOutOfStock(ProductListResult product)
        {
            try
            {
                var productData = new ProductDataAccess();
                productData.MarkOutOfStock(product);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query didn't work ...");

            }
        }
		[HttpGet, Route("status/{id}")]
		public HttpResponseMessage GetProductStatus(int id)
		{
			using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
			{
				try
				{

					var ProductData = new ProductDataAccess();
					var ProductStatus = ProductData.CheckStock(id);
					
					return Request.CreateResponse(HttpStatusCode.OK, ProductStatus);
				}
				catch (Exception ex)
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
				}
			}
		}
	}
}
