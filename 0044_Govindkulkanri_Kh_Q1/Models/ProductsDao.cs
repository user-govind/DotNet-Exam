using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam_210940320044_KH.Models
{
    public class ProductsDao
    {
        SqlConnection conn;

        void OpenDBConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExamDB_0044;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();

        }

        public List<Product> getAllProducts()
        {
            OpenDBConnection();

            SqlCommand cmdSelectAll = new SqlCommand();

            cmdSelectAll.Connection = conn;
            cmdSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelectAll.CommandText = "getAllProducts";

            SqlDataReader dr = cmdSelectAll.ExecuteReader();

            List<Product> allProductsList = new List<Product>();

            while (dr.Read())
            {
                allProductsList.Add(new Product
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                });
            }

            dr.Close();
            conn.Close();

            return allProductsList;
        }

        public Product getOneProduct(int id)
        {
            OpenDBConnection();
            SqlCommand cmdSelectOne = new SqlCommand();

            cmdSelectOne.Connection = conn;
            cmdSelectOne.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelectOne.CommandText = "getOneProduct";

            cmdSelectOne.Parameters.AddWithValue("@ProductId", id);

            SqlDataReader dr = cmdSelectOne.ExecuteReader();

            Product p=null;
            while (dr.Read())
            {
                p = new Product
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                };
            }
            dr.Close();
            conn.Close();

            return p;

        }

        public bool UpdateProduct(Product p)
        {
            OpenDBConnection();
            SqlCommand cmdSelectOne = new SqlCommand();

            cmdSelectOne.Connection = conn;
            cmdSelectOne.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelectOne.CommandText = "UpdateProduct";

            cmdSelectOne.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmdSelectOne.Parameters.AddWithValue("@ProductId", p.ProductId);
            cmdSelectOne.Parameters.AddWithValue("@Rate", p.Rate);
            cmdSelectOne.Parameters.AddWithValue("@Description", p.Description);
            cmdSelectOne.Parameters.AddWithValue("@CategoryName", p.CategoryName);

            cmdSelectOne.ExecuteNonQuery();

            return true;
        }

        
    }
}