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
    public class OrderDataAccess : IOrdersRepository<OrderDetails>
    {

        //placeanorder
        public void Add()
        {
            throw new NotImplementedException();
        }

        //pay for an order
        public int UpdatePaid(int id, OrderDetails order)
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute
                                              ("update Orders " +
                                               "set Paid = 1 " +
                                               "where EmployeeId = @employeeId",
                                               new
                                               {
                                                   employeeId = id
                                               });

                return affectedRows;

            }
        }

        //listordersunpaidorders
        public List<OrderDetails> ListUnpaid()
        {
            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Query<OrderDetails>("select * " +
                                                            "from Order " +
                                                            "where Paid = false");

                return result.ToList();
            }
        }
        
    }

    public interface IOrdersRepository<T>
    {
        void Add();
        int UpdatePaid(int id, T entityToUpdate);
        List<T> ListUnpaid();
    }
}