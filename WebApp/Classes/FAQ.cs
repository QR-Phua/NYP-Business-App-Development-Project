using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApp
{
    public class FAQ
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _faq_ID = "";
        private string _faq_Title = "";
        private string _faq_Question = "";
        private string _faq_Answer = "";


        // Default constructor
        public FAQ()
        {
        }
        public FAQ(string faq_ID, string faq_Title, string faq_Question, string faq_Answer)
        {
            _faq_ID = faq_ID;
            _faq_Title = faq_Title;
            _faq_Question = faq_Question;
            _faq_Answer = faq_Answer;
        }



        // Constructor that take in all except Ingredient ID
        public FAQ(string faq_Title, string faq_Question, string faq_Answer)
            : this(null, faq_Title, faq_Question, faq_Answer)
        {
        }

        // Constructor that take in only Ingredient ID. The other attributes will be set to 0 or empty.
        public FAQ(string faq_ID)
            : this(faq_ID, "", "", "")
        {
        }

        public string faq_ID
        {
            get { return _faq_ID; }
            set { _faq_ID = value; }
        }

        public string faq_Title
        {
            get { return _faq_Title; }
            set { _faq_Title = value; }
        }
        public string faq_Question
        {
            get { return _faq_Question; }
            set { _faq_Question = value; }
        }

        public string faq_Answer
        {
            get { return _faq_Answer; }
            set { _faq_Answer = value; }
        }

        public FAQ getfaq(string faq_ID)
        {
            FAQ FAQdetail = null;

            string faq_Title, faq_Question, faq_Answer;

            string querystr = "select * from FAQ where faq_id = @faqid";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@faqid", faq_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                faq_ID = dr["faq_ID"].ToString();
                faq_Title = dr["faq_Title"].ToString();
                faq_Question = dr["faq_Question"].ToString();
                faq_Answer = dr["faq_Answer"].ToString();


                FAQdetail = new FAQ(faq_ID, faq_Title, faq_Question, faq_Answer);
            }
            else
            {
                FAQdetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return FAQdetail;

        }


        public List<FAQ> getfaqall()
        {
            List<FAQ> faqList = new List<FAQ>();
            string faq_ID, faq_Title, faq_Question, faq_Answer;

            string queryStr = "select * from FAQ order by faq_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                faq_ID = dr["faq_ID"].ToString();
                faq_Title = dr["faq_Title"].ToString();
                faq_Question = dr["faq_Question"].ToString();
                faq_Answer = dr["faq_Answer"].ToString();

                FAQ a = new FAQ(faq_ID, faq_Title, faq_Question, faq_Answer);
                faqList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return faqList;
        }

        public int FAQInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO faq(faq_ID, faq_Title, faq_Question, faq_Answer)"
                + " values (@faq_ID, @faq_Title, @faq_Question, @faq_Answer)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@faq_ID", this._faq_ID);
            cmd.Parameters.AddWithValue("@faq_Title", this._faq_Title);
            cmd.Parameters.AddWithValue("@faq_Question", this._faq_Question);
            cmd.Parameters.AddWithValue("@faq_Answer", this._faq_Answer);

            conn.Open();
            result += cmd.ExecuteNonQuery(); 
            conn.Close();

            return result;
        }

        public int FAQDelete(string ID)
        {
            string queryStr = "DELETE FROM Faq WHERE faq_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }



        public int FAQUpdate(string fID,  string fTitle,string fQuestion, string fAnswer)
        {
            string queryStr = "UPDATE FAQ SET" +
                " faq_Title = @faq_Title, " +
                " faq_Question = @faq_Question, " +
                " faq_Answer = @faq_Answer " + 
                " WHERE faq_ID = @faq_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@faq_Question", fQuestion);
            cmd.Parameters.AddWithValue("@faq_Answer", fAnswer);
            cmd.Parameters.AddWithValue("@faq_Title", fTitle);
            cmd.Parameters.AddWithValue("@faq_ID", fID);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }




    }
}