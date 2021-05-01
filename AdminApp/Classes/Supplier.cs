using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AdminApp
{
    public class Supplier
    {

        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _suppl_ID = "";
        private string _suppl_Name = "";
        private string _suppl_Contact = "";
        private string _suppl_Email = "";
        private string _suppl_Address = "";

        public Supplier()
        {
        }

        public Supplier(string suppl_ID, string suppl_Name, string suppl_Contact, string suppl_Email, string suppl_Address)
        {
            _suppl_ID = suppl_ID;
            _suppl_Name = suppl_Name;
            _suppl_Contact = suppl_Contact;
            _suppl_Email = suppl_Email;
            _suppl_Address = suppl_Address;
        }

        public Supplier(string suppl_Name, string suppl_Contact, string suppl_Email, string suppl_Address)
            : this(null, suppl_Name, suppl_Contact, suppl_Email, suppl_Address)
        {
        }
        
        public Supplier(string suppl_ID)
       
            : this(suppl_ID, "", "", "", "")
        {
        }
        
        public string suppl_ID
        {
            get { return _suppl_ID; }
            set { _suppl_ID = value; }
        }

        public string suppl_Name
        {
            get { return _suppl_Name; }
            set { _suppl_Name = value; }
        }

        public string suppl_Contact
        {
            get { return _suppl_Contact; }
            set { _suppl_Contact = value; }
        }

        public string suppl_Email
        {
            get { return _suppl_Email; }
            set { _suppl_Email = value; }
        }

        public string suppl_Address
        {
            get { return _suppl_Address; }
            set { _suppl_Address = value; }
        }

        // class method
        //GET
        public Supplier getSupplier(string suppl_ID)
        {

            Supplier supDetail = null;

            string suppl_Name, suppl_Contact, suppl_Email, suppl_Address;

            string queryStr = "SELECT * FROM Supplier WHERE suppl_ID = @SupID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@SupID", suppl_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                suppl_Name = dr["suppl_Name"].ToString();
                suppl_Contact = dr["suppl_Contact"].ToString();
                suppl_Email = dr["suppl_Email"].ToString();
                suppl_Address = dr["suppl_Address"].ToString();


                supDetail = new Supplier(suppl_ID, suppl_Name, suppl_Contact, suppl_Email, suppl_Address);
            }
            else
            {
                supDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return supDetail;
        }
        // GET ALL

        public List<Supplier> getSupplierAll()
        {
            List<Supplier> supList = new List<Supplier>();

            string suppl_Name, suppl_Contact, suppl_Email, suppl_Address, suppl_ID;


            string queryStr = "SELECT * FROM Supplier Order By suppl_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                suppl_ID = dr["suppl_ID"].ToString();
                suppl_Name = dr["suppl_Name"].ToString();
                suppl_Contact = dr["suppl_Contact"].ToString();
                suppl_Email = dr["suppl_Email"].ToString();
                suppl_Address = dr["suppl_Address"].ToString();
                Supplier a = new Supplier(suppl_ID, suppl_Name, suppl_Contact, suppl_Email, suppl_Address);
                supList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return supList;
        }

        //INSERT
        public int SupplierInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Supplier(suppl_ID, suppl_Name, suppl_Contact, suppl_Email, suppl_Address)"
                + " values (@suppl_ID, @suppl_Name, @suppl_Contact, @suppl_Email, @suppl_Address)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@suppl_ID", this.suppl_ID);
            cmd.Parameters.AddWithValue("@suppl_Name", this.suppl_Name);
            cmd.Parameters.AddWithValue("@suppl_Contact", this.suppl_Contact);
            cmd.Parameters.AddWithValue("@suppl_Email", this.suppl_Email);
            cmd.Parameters.AddWithValue("@suppl_Address", this.suppl_Address);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        //DELETE
        public int SupplierDelete(string ID)
        {
            string queryStr = "DELETE FROM Supplier WHERE suppl_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

        //UPDATE
        public int SupplierUpdate(string sId, string sName, string sContact, string sEmail, string sAddress)
        {
            string queryStr = "UPDATE Supplier SET" +
                //" Product_ID = @productID, " +
                " suppl_Name = @suppl_Name, " +
                " suppl_Contact = @suppl_Contact, " +
                " suppl_Email = @suppl_Email, " +
                " suppl_Address = @suppl_Address " +
                " WHERE suppl_ID = @suppl_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@suppl_ID", sId);
            cmd.Parameters.AddWithValue("@suppl_Name", sName);
            cmd.Parameters.AddWithValue("@suppl_Contact", sContact);
            cmd.Parameters.AddWithValue("@suppl_Email", sEmail);
            cmd.Parameters.AddWithValue("@suppl_Address", sAddress);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update
























    }
}