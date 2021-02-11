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

        public Formulation(string ingredient1, string ingredient2, string ingredient3)
        {
            _ingredient1 = ingredient1;
            _ingredient2 = ingredient2;
            _ingredient3 = ingredient3;
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

        public List<string> recommendationIngredientsRetrieve(string formulationID)
        {
            string queryStr = "SELECT ingredient1, ingredient2, ingredient3 FROM Formulation WHERE formulation_ID = @formulationID";

            Debug.WriteLine("Retrieving Ingredients");
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@formulationID", formulationID);

            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            conn.Close();

            List<string> list = new List<string>();
            string ingredient1 = "", ingredient2 = "", ingredient3 = "";
            foreach (DataRow row in dt.Rows)
            {
                ingredient1 = row["ingredient1"].ToString();
                ingredient2 = row["ingredient2"].ToString();
                ingredient3 = row["ingredient3"].ToString();
            }

            list.Add(ingredient1);
            Debug.WriteLine(ingredient1);
            list.Add(ingredient2);
            Debug.WriteLine(ingredient2);
            list.Add(ingredient3);
            Debug.WriteLine(ingredient3);
            
            return list;
        }

        public string retrieveFormulationID()
        {
            string queryStr = "SELECT formulation_ID FROM Formulation WHERE (ingredient1 = @ingredient1 AND ingredient2 = @ingredient2 AND ingredient3 = @ingredient3)";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ingredient1", this.ingredient1);
            cmd.Parameters.AddWithValue("@ingredient2", this.ingredient2);
            cmd.Parameters.AddWithValue("@ingredient3", this.ingredient3);
            Debug.WriteLine("Getting Formulation ID !");

            string formulationID = "";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    formulationID = reader["formulation_ID"].ToString();
                }
            }
            finally
            {
                reader.Close();
            }

                        
            return formulationID;
        }


        public DataTable retrieveRecommendations(string resultID)
        {
            string queryStr = "SELECT DISTINCT r.formulation_ID FormulationID, ROUND(AVG(rating),2) Percentage FROM Orders o INNER JOIN Review r ON o.order_ID = r.order_ID "
                               + "WHERE o.result_ID = @resultID "
                               + "GROUP BY r.formulation_ID "
                               + "ORDER BY Percentage desc; ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@resultID", resultID);

            Debug.WriteLine("Getting formulationIDs of products bought with the same resultID !");

            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            
            sda.Fill(dt);
            conn.Close();
            Debug.WriteLine("DataTable for the various formulationIDs created. Results below vv");
            
            if (dt.Rows.Count > 0)
            {
                Debug.WriteLine("DT IS NOT EMPTY!");
                foreach (DataRow row in dt.Rows)
                {
                    Debug.WriteLine(string.Format("Formulation ID: {0} has a rating of {1}", row["FormulationID"], row["Percentage"]));
                }
                return dt;
            }
            else
            {
                Debug.WriteLine("DT IS EMPTY!");
                return dt;
            }
            
        }
    }
}