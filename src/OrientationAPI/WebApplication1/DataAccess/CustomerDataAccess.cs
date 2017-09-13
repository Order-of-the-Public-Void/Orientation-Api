using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using WebApplication1.Models;


namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess : IRepository<CustomerListResult>
    {

        public List<CustomerListResult> GetAll()
        {
            using (var connection =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))

            {

                connection.Open();

                var result = connection.Query<CustomerListResult>
                                              ("select * from Customer");

                return result.ToList();
            }
        }

        public bool InactivateCustomer(int entitytoUpdate)
        {
            var newStatus = 0;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var successful = connection.Execute("Update Customer set Active = @Active Where CustomerId = @CustomerId",
                    new { CustomerId = entitytoUpdate, Active = newStatus });

                if (successful == 1)
                    return true;
                else
                    return false;

            }
        }

        public void Update(CustomerListResult customer)
        {
            using (var connection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();
                var result = connection.Execute("Update Customer " +
                                                                "Set FirstName = @firstname, LastName = @lastname " +
                                                                "Where CustomerId = @customerId", new { FirstName = customer.FirstName, LastName = customer.LastName, CustomerId = customer.CustomerId });
                return;
            }
        }

    }

    public interface IRepository<T>
    {
        List<T> GetAll();
        bool InactivateCustomer(int entityToUpdate);
        void Update(T entityToUpdate);
    }
}