using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataAccess;

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

        [HttpPost, Route("placeOrder")]
        public HttpResponseMessage PlaceOrder()
        {          
            try
            {
                var newOrder = new OrderDataAccess.PlaceAnOrder();
                return Request.CreateResponse(HttpStatusCode.Created, newOrder);

                var isAvail = new ProductDataAccess.GetProductStatus(id);
                return Request.CreateResponse(HttpStatusCode.Found, isAvail);

                if (isAvail)
                {
                    var insertLineItem = new OrderDataAccess.InsertLineItem(newOrder);
                    return Request.CreateResponse(HttpStatusCode.Created, insertLineItem);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item not available...");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Order not created ...");
            }


        }

        [HttpPut, Route("paid")]
        public HttpResponseMessage MarkPaid()
        {
            throw new NotImplementedException();
        }
    }
}
