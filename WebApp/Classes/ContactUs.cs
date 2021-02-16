using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace WebApp
{

    public class ContactUs
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _ContactUs_ID = "";
        private string _ContactUs_FirstName = "";
        private string _ContactUs_LastName = "";
        private string _ContactUs_Email = "";
        private string _ContactUs_Mobile = "";
        private string _ContactUs_Message = "";
        private string _ContactUs_ProdName = "";
        private string _ContactUs_Feedback = "";

        public ContactUs(string ContactUs_ID, string ContactUs_FirstName, string ContactUs_LastName, string ContactUs_Email, int ContactUs_Mobile, string ContactUs_Message, string ContactUs_ProdName, string ContactUs_Feedback)
        {

            _ContactUs_ID = ContactUs_ID;
            _ContactUs_FirstName = ContactUs_FirstName;
            _ContactUs_LastName = ContactUs_LastName;
            _ContactUs_Email = ContactUs_Email;
            _ContactUs_Mobile = ContactUs_Mobile;
            _ContactUs_Message = ContactUs_Message;
            _ContactUs_ProdName = ContactUs_ProdName;
            _ContactUs_Feedback = ContactUs_Feedback;

        }

        public ContactUs(string ContactUs_ID, string ContactUs_FirstName, string ContactUs_LastName, string ContactUs_Email, int ContactUs_Mobile, string ContactUs_Message, string ContactUs_ProdName, string ContactUs_Feedback)
            : this(null, ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Mobile, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback)
        {        
        }

        public ContactUs(string ContactUs_ID)
            : this(ContactUs_ID, "", "", "")
        {
        }

        public string ContactUs_ID
        {
            get { return _ContactUs_ID; }
            set { _ContactUs_ID = value; }
        }

        public string ContactUs_FirstName
        {
            get { return _ContactUs_FirstName; }
            set { _ContactUs_FirstName = value; }
        }

        public string ContactUs_LastName
        {
            get { return _ContactUs_LastName; }
            set { _fContactUs_LastName = value; }
        }

        public string ContactUs_Email
        {
            get { return _ContactUs_Email; }
            set { _ContactUs_Email = value; }
        }

        public int ContactUs_Mobile
        {
            get { return _ContactUs_Mobile; }
            set { _ContactUs_ Mobile = value; }
        }

        public string ContactUs_Message
        {
            get { return _ContactUs_Message; }
            set { _ContactUs_Message = value; }
        }

        public string ContactUs_ProdName
        {
            get { return _ContactUs_ProdName; }
            set { _fContactUs_ProdName = value; }
        }

        public string ContactUs_Feedback
        {
            get { return _ContactUs_Feedback; }
            set { _ContactUs_Feedback = value; }
        }

        public ContactUs getcontactUs(string ContactUs_ID)
        {
            ContactUs ContactUsdetail = null;

            string ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback;
            int ContactUs_Mobile;

            string querystr = "select * from ContactUs where contactus_id = @contactusid";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@contactusid", ContactUs_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ContactUs_ID = dr["ContactUs_ID"].ToString();
                ContactUs_FirstName = dr["ContactUs_FirstName"].ToString();
                ContactUs_LastName = dr["ContactUs_LastName"].ToString();
                ContactUs_Email = dr["ContactUs_Email"].ToString();
                ContactUs_Mobile = int.Parse(dr["ContactUs_Mobile"].ToString());
                ContactUs_Message = dr["ContactUs_Message"].ToString();
                ContactUs_ProdName = dr["ContactUs_ProdName"].ToString();
                ContactUs_Feedback = dr["ContactUs_Feedback"].ToString();

                ContactUsdetail = new ContactUs(ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Mobile, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback);
            }

            else
            {
                ContactUsdetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return ContactUsdetail;

        }

        public List<ContactUs> getcontactusall()
        {
            List<ContactUs> ContactUsList = new List<ContactUs>();
            string ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback;
            int ContactUs_Mobile;

            string queryStr = "select * from ContactUs';
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ContactUs_ID = dr["ContactUs_ID"].ToString();
                ContactUs_FirstName = dr["ContactUs_FirstName"].ToString();
                ContactUs_LastName = dr["ContactUs_LastName"].ToString();
                ContactUs_Email = dr["ContactUs_Email"].ToString();
                ContactUs_Mobile = int.Parse(dr["ContactUs_Mobile"].ToString());
                ContactUs_Message = dr["ContactUs_Message"].ToString();
                ContactUs_ProdName = dr["ContactUs_ProdName"].ToString();
                ContactUs_Feedback = dr["ContactUs_Feedback"].ToString()

                ContactUs a = new ContactUs(ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Mobile, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback);
                ContactUsList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return ContactUsList;
        }

        public int ContactUsInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO contactus(ContactUs_ID, ContactUs_FirstName, ContactUs_LastName, ContactUs_Email, ContactUs_Mobile, ContactUs_Message, ContactUs_ProdName, ContactUs_Feedback)"
                + " values (@ContactUs_ID, @ContactUs_FirstName, @ContactUs_LastName, @ContactUs_Email, @ContactUs_Mobile, @ContactUs_Message, @ContactUs_ProdName, @ContactUs_Feedback)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ContactUs_ID", this._ContactUs_ID);
            cmd.Parameters.AddWithValue("@ContactUs_FirstName", this._ContactUs_FirstName);
            cmd.Parameters.AddWithValue("@ContactUs_LastName", this._ContactUs_LastName);
            cmd.Parameters.AddWithValue("@ContactUs_Email", this._ContactUs_Email);
            cmd.Parameters.AddWithValue("@ContactUs_Mobile", this._ContactUs_Mobile);
            cmd.Parameters.AddWithValue("@ContactUs_Message", this._ContactUs_Message);
            cmd.Parameters.AddWithValue("@ContactUs_ProdName", this._ContactUs_ProdName);
            cmd.Parameters.AddWithValue("@ContactUs_Feedback", this._ContactUs_Feedback);

            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int ContactUsDelete(string ID)
        {
            string queryStr = "DELETE FROM Contactus WHERE ContactUs_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }

        public int ContactUsUpdate(string cID, string cFirstName, string cLastName, string cEmail, int cMobile, string cMessage, string cProdName, string cFeedback)
        {
            string queryStr = "UPDATE Contact Us SET" +
                " ContactUs_FirstName = @ ContactUs_FirstName, " +
                " ContactUs_LastName = @ContactUs_LastName, " +
                " ContactUs_Email = @ContactUs_Email, " +
                " ContactUs_Mobile = @ContactUs_Mobile, " +
                " ContactUs_Message = @ContactUs_Message, " +
                " ContactUs_ProdName = @ContactUs_ProdName, " +
                " ContactUs_Feedback = @ContactUs_Feedback, " +
                " WHERE faq_ID = @faq_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ContactUs_ID", cID);
            cmd.Parameters.AddWithValue("@ContactUs_FirstName", cFirstName);
            cmd.Parameters.AddWithValue("@ContactUs_LastName", cLastName);
            cmd.Parameters.AddWithValue("@ContactUs_Email", cEmail);
            cmd.Parameters.AddWithValue("@ContactUs_Mobile", cMobile);
            cmd.Parameters.AddWithValue("@ContactUs_Message", cMessage);
            cmd.Parameters.AddWithValue("@ContactUs_ProdName",cProdName);
            cmd.Parameters.AddWithValue("@ContactUs_Feedback", cFeedback);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }
    }
