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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [HttpGet, Route("unpaid")]
        public HttpResponseMessage GetUnPaid()
        {
            try
            {
                var orderData = new OrderDataAccess();
                var orders = orderData.ListUnpaid();

                return Request.CreateResponse(HttpStatusCode.OK, orders);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query didn't work ...");
            }
        }

        [HttpPost, Route("create")]
        public HttpResponseMessage CreateOrder()
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("paid/{id}")]
        public HttpResponseMessage MarkPaid(int id, OrderDetails order)
        {
            try
            {
                var orderData = new OrderDataAccess();
                var affectedRows = orderData.UpdatePaid(id, order);

                if (affectedRows == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                   $"Order not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, $"{affectedRows} rows updated");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
