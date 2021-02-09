using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab06
{
    public class Customer
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _CustFirstName;
        private string _CustLastName;
        private string _Password;
        private string _Gender;
        private string _Email;
        private string _PhoneNumber;
        private string _Address;
        private string _PaymentMethod;

        public Customer()
        {
        }

        public Customer(string Email, string CustFirstName, string CustLastName, string Password,
                           string Gender, string PhoneNumber, string Address, string PaymentMethod)
        {
            _Email = Email;
            _CustFirstName = CustFirstName;
            _CustLastName = CustLastName;
            _Password = Password;
            _Gender = Gender;
            _PhoneNumber = PhoneNumber;
            _Address = Address;
            _PaymentMethod = PaymentMethod;

        }

        public string Cust_Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Cust_First_Name
        {
            get { return _CustFirstName; }
            set { _CustFirstName = value; }
        }
        public string Cust_Last_Name
        {
            get { return _CustLastName; }
            set { _CustLastName = value; }
        }
        public string Cust_Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Cust_Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string PaymentMethod
        {
            get { return _PaymentMethod; }
            set { _PaymentMethod = value; }
        }

        public int CustomerInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Customers(Cust_Email,Cust_First_Name,Cust_Last_Name, Cust_Password, Cust_Gender, PhoneNumber,Address,PaymentMethod)"
                + " values (@Cust_Email,@Cust_First_Name,@Cust_Last_Name, @Cust_Password, @Cust_Gender, @PhoneNumber, @Address, @PaymentMethod)";
            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@Cust_Email", this.Cust_Email);
                cmd.Parameters.AddWithValue("@Cust_First_Name", this.Cust_First_Name);
                cmd.Parameters.AddWithValue("@Cust_Last_Name", this.Cust_Last_Name);
                cmd.Parameters.AddWithValue("@Cust_Password", this.Cust_Password);
                cmd.Parameters.AddWithValue("@Cust_Gender", this.Cust_Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", this.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", this.Address);
                cmd.Parameters.AddWithValue("@PaymentMethod", this.PaymentMethod);

                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();

                return result;
            }
            catch (Exception ex)
            { return 0; }
        }//end Insert
    }
}