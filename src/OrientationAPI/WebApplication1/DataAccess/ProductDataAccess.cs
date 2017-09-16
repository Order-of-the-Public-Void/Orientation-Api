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
    public class ProductDataAccess : IProductRepository<ProductListResult>
    {
        public List<ProductListResult> GetAllProducts()
        {

            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.Query<ProductListResult>
                                              ("select * from Product");

                return result.ToList();
            }
        }

        public List<ProductListResult> CreateProduct()
        {
            throw new NotImplementedException();
        }

        public List<ProductListResult> DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void MarkOutOfStock(ProductListResult entityToUpdate)
        {

            using (var connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var result = connection.ExecuteScalar<ProductListResult>
                                              ("update Product set OutOfStock = ~OutOfStock where Product.ProductId = @productId", new { ProductId = entityToUpdate.ProductId});

            }
        }
		public bool CheckStock(int id)
		{
			using (var connection =
			new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
			{
				connection.Open();

				var result = connection.QueryFirstOrDefault<bool>("Select OutOfStock From Product where ProductId = @id", new { id = id });

				return result;
			}
		}
	}
    public interface IProductRepository<T>
    {
        List<T> GetAllProducts();
        List<T> CreateProduct();
        List<T> DeleteProduct();
        void MarkOutOfStock(ProductListResult entityToUpdate);
		bool CheckStock(int id);
    }
}