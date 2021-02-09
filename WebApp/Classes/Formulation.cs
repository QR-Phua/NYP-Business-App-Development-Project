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
    public class Formulation
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;

        private string _formulationID = "";
        private string _ingredient1 = "";
        private string _ingredient2 = "";
        private string _ingredient3 = "";

        public Formulation(string formulationID)
        {
            _formulationID = formulationID;
        }

        public Formulation()
        {

        }

        public string formulationID
        {
            get { return _formulationID; }
            set { _formulationID = value; }
        }

        public string ingredient1
        {
            get { return _ingredient1; }
            set { _ingredient1 = value; }
        }

        public string ingredient2
        {
            get { return _ingredient2; }
            set { _ingredient2 = value; }
        }

        public string ingredient3
        {
            get { return _ingredient3; }
            set { _ingredient3 = value; }
        }

        public void retrieveIngredients()
        {
            
            string queryStr = "SELECT ingredient1, ingredient2, ingredient3 FROM Formulation WHERE formulation_ID = @formulationID";

            Debug.WriteLine("Retrieving Ingredients from orders");
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@formulationID", this.formulationID);

            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            conn.Close();

            foreach (DataRow row in dt.Rows)
            {
                this.ingredient1 = row["ingredient1"].ToString();
                this.ingredient2 = row["ingredient2"].ToString();
                this.ingredient3 = row["ingredient3"].ToString();
            }

        }

        public bool addFormulation()
        {
            bool formulationExist = false;
            Debug.WriteLine("Check if formulation exists");
            try
            {
                string queryStr = "SELECT cart_ID FROM Formulation WHERE formulation_ID = @formulation_ID";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@formulation_ID", this.formulationID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("Formulation Exist!");
                        formulationExist = true;

                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Formulation do not exist!");
                   
                    Debug.WriteLine(ex);
                }
                reader.Close();
                conn.Close();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Something went wrong reading Formulation Table");
                Debug.WriteLine(ex);
            }

            if (formulationExist)
            {
                Debug.WriteLine("Formulation Exists!");
                return true;
            }
            else
            {
                Debug.WriteLine("Formulation does not exist! Adding Formulation to Database now");
                bool result = false;

                string queryStr = "INSERT INTO Formulation(formulation_ID,ingredient1,ingredient2,ingredient3)"
                    + " values (@formulation_ID,@ingredient1,@ingredient2,@ingredient3)";

                try
                {
                    Debug.WriteLine("Attempting to add Formulation");

                    int firstInsert = 0;
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@cart_ID", this.formulationID);
                    cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1);
                    cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2);
                    cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3);


                    conn.Open();
                    firstInsert += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                    conn.Close();

                    if (firstInsert > 0)
                    {
                        Debug.WriteLine("Formulation Added Successfully");
                        result = true;
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Something went wrong adding Formulation. Error below");
                    Debug.WriteLine(ex);
                }

                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
               
        }
    }
}