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

        
        private int _reviewID = new Random().Next(1,999999999);
        private string _formulationID = "";
        private int _orderID = 0;
        private int _rating = 0;
        private DateTime __timeStamp = DateTime.UtcNow;

        public Review()
        {

        }

        public Review(string formulationID, int orderID, int rating)
        {
            _formulationID = formulationID;
            _orderID = orderID;
            _rating = rating;
        }

        public string reviewID
        {
            get { return _reviewID.ToString(); }
            set { _reviewID = int.Parse(value); }
        }

        public string formulationID
        {
            get { return _formulationID; }
            set { _formulationID = value; }
        }

        public string orderID
        {
            get { return _orderID.ToString(); }
            set { _orderID = int.Parse(value); }
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

        
        public bool ReviewInsert()
        {
            bool result = false;

            string queryStr = "INSERT INTO Review(review_ID, order_ID, rating, formulation_ID, date)"
                + "VALUES (@review_ID, @order_ID, @rating, @formulation_ID, @date )";
            SqlConnection conn = new SqlConnection(_connStr);
            try
            {
                Debug.WriteLine("Adding Review");
                int rows = 0;
                
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@review_ID", this.reviewID);
                cmd.Parameters.AddWithValue("@order_ID", this.orderID);
                cmd.Parameters.AddWithValue("@rating", this.rating);
                cmd.Parameters.AddWithValue("@formulation_ID", this.formulationID);
                cmd.Parameters.AddWithValue("@date", this.date);

                conn.Open();
                rows += cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    Debug.WriteLine("Review Added!");
                    Debug.WriteLine("Completed adding of Review");
                    result = true;
                }
            } 
            catch (SqlException ex)
            {
                Debug.WriteLine("Something went wrong adding the review. Error below");
                Debug.WriteLine(ex);
            }

            if (result)
            {
                Debug.Write("UPDATING review attribute in order rn !");
                int rowsAffected = 0;
                string query = "UPDATE Orders SET reviewed = 'True' WHERE order_ID = @orderID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderID", this.orderID);
                
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    Debug.WriteLine("Update completed!");
                    result = true;
                    return result;
                }
                else
                {
                    Debug.WriteLine("Update failed!");
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


                
    }
}