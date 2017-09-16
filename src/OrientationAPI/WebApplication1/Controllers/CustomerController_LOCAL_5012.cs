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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        //customers
        [HttpGet, Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var customerData = new CustomerDataAccess();
                var customers = customerData.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception)
            {
		        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query didn't work ...");
            }
        }
        [HttpPost, Route("add")]
        public HttpResponseMessage Post(CustomerListResult customer)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                try
                {
                    var customerData = new CustomerDataAccess();
                    customerData.Add(customer);
                    return Request.CreateResponse(HttpStatusCode.Accepted);

                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

                }
            }
        }
        [HttpPut, Route("edit")]
		public HttpResponseMessage Put(CustomerListResult customer)
		{
			using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
			{
				try
				{
					var customerData = new CustomerDataAccess();
					customerData.Update(customer) ;
					return Request.CreateResponse(HttpStatusCode.Accepted);

				}
				catch (Exception ex)
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

				}
			}
		}
        // PUT api/values/5
        [HttpPut, Route("{id}")]
        public HttpResponseMessage InactivateCustomer(int id)
        {
            var customerDataAccess = new CustomerDataAccess();
            var MakeInactive = customerDataAccess.InactivateCustomer(id);
           
            if(MakeInactive)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
    }
}