using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.DataAccess
{
    public class OrderDataAccess : IOrdersRepository<OrderDetails>
    {

        //placeanorder
        public int PlaceAnOrder(OrderDetails entityToInsert)   
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var newOrder = connection.ExecuteScalar<int>(
                    @"INSERT into Order (OrderId,OrderTotal,Paid,CustomerId) Values(@OrderId,@OrderTotal,@Paid,@CustomerId) select Cast(Scope_Identity() as int);",
                        entityToInsert);

                return newOrder;

             }
        }

        //payforanorder
        public void Update()
        {
            throw new NotImplementedException();
        }

        //listordersunpaidorders
        public List<T> ListUnPaid()
        {
            throw new NotImplementedException();
        }

        //insert LineItems
        public int InsertLineItem(ProductListResult entityToInsert)
        {
            //var isAvail = true;//new ProductDataAccess.GetProductStatus(productId);

            //if (isAvail)
            //{
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var newLineItem = connection.ExecuteScalar("Insert into LineItem (OrderId, ProductId, Quantity)" +
                "Values(@OrderId, @ProductId, @Quantity)",
                new
                {
                    OrderId = newOrder,
                    productId = newLineItem.productId,
                    Quantity = newLineItem.Quantity
                });
            }
            //}
        }

    }

    public interface IOrdersRepository<T>
    {
        int PlaceAnOrder(T entityToInsert);
        void Update();
        List<T> ListUnPaid();
        int InsertLineItem(ProductListResult entityToInsert);
    }
}