using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Review
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;

        private string _reviewID = Guid.NewGuid().ToString();
        private string _formulationID = "";
        private string _orderID = "";
        private int _rating = 0;
        private DateTime __timeStamp = DateTime.UtcNow;

        public Review()
        {

        }

        public Review(string formulationID, string orderID, int rating)
        {
            _formulationID = formulationID;
            _orderID = orderID;
            _rating = rating;
        }

        public string reviewID
        {
            get { return _reviewID; }
            set { _reviewID = value; }
        }

        public string formulationID
        {
            get { return _formulationID; }
            set { _formulationID = value; }
        }

        public string orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public int rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public DateTime date
        {
            get { return __timeStamp; }
            set { __timeStamp = value; }
        }

        
        public bool ReviewInsert(int rating)
        {
            bool result = false;

            string queryStr = "INSERT INTO Review(review_ID, order_ID, rating, formulation_ID, date)"
                + "VALUES (@review_ID, @order_ID, @rating, @formulation_ID, @date )";

            try
            {
                Debug.WriteLine("Adding Review");
                int rows = 0;
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@review_ID", this.reviewID);
                cmd.Parameters.AddWithValue("@order_ID", this.orderID);
                cmd.Parameters.AddWithValue("@rating", this.rating);
                cmd.Parameters.AddWithValue("@formulation_ID", this.formulationID);
                cmd.Parameters.AddWithValue("@date", this.date);

                conn.Open();
                rows += cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 1)
                {
                    Debug.WriteLine("Completed adding of Review");
                    result = true;
                }
            } 
            catch (SqlException ex)
            {
                Debug.WriteLine("Something went wrong adding the review. Error below");
                Debug.WriteLine(ex);
            }

            return result;

        }

        public void retrieveRecommendations(string result, string ingredient1, string ingredient2, string ingredient3)
        {
            
        }
        
    }
}