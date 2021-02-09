using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Lab06
{
    public class PaymentDetails
    {
        string _connStr = ConfigurationManager.ConnectionStrings["HealthDBContext"].ConnectionString;
        private string _paymentID = null;
        private string _customerID = "";
        private string _date = "";
        private string _paymentType = "";
        private string _status = "";

        public PaymentDetails()
        {
        }

        public PaymentDetails(string paymentID, string customerID, string date, string paymentType, string status )
        {
            _paymentID = paymentID;
            _customerID = customerID;
            _date = date;
            _paymentType = paymentType;
            _status = status;
 
        }

        public PaymentDetails(string customerID,string date, string paymentType, string status )
            : this(null, customerID, date, paymentType, status )
        {
        }


        public PaymentDetails(string paymentID)
            : this(paymentID, "", "","","")
        {
        }


        public string Payment_ID
        {
            get { return _paymentID; }
            set { _paymentID = value; }
        }

        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public string OrderDate
        {
            get { return _date; }
            set { _date = value; }
        }
        public string PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }


        public PaymentDetails getPayment(string paymentID)
        {

            PaymentDetails payDetails = null;
           
            string  date, payment_Type, status;

            string queryStr = "SELECT * FROM OrderPayment WHERE Payment_ID = @PaymentID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@PaymentID", paymentID);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                date = dr["OrderDate"].ToString();
                payment_Type = dr["PaymentType"].ToString();
                status = dr["Status"].ToString();

                payDetails = new PaymentDetails(paymentID, date, payment_Type, status);
            }
            else
            {
                payDetails = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return payDetails;
        }


        //

        public List<PaymentDetails> getPaymentDetailsAll()
        {
            List<PaymentDetails> payList = new List<PaymentDetails>();

            string payment_ID,customerID,date, payment_Type,status;

            string queryStr = "SELECT * FROM OrderPayment Order By Payment_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                payment_ID = dr["Payment_ID"].ToString();
                customerID = dr["CustomerID"].ToString();
                date = dr["OrderDate"].ToString();
                payment_Type = dr["PaymentType"].ToString();
                status = dr["Status"].ToString();

                PaymentDetails a = new PaymentDetails(payment_ID,customerID, date, payment_Type, status);
                payList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return payList;
        }

        //



        public int PaymentInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO OrderPayment(Payment_ID,CustomerID,OrderDate,PaymentType,Status)"
                + " values (@Payment_ID,@CustomerID,@OrderDate,@PaymentType,@Status)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Payment_ID", this.Payment_ID);
            cmd.Parameters.AddWithValue("@CustomerID", this.CustomerID);
            cmd.Parameters.AddWithValue("@OrderDate", this.OrderDate);
            cmd.Parameters.AddWithValue("@PaymentType", this.PaymentType);
            cmd.Parameters.AddWithValue("@Status", this.Status);



            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert






    }
}