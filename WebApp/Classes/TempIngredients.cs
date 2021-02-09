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
    public class TempIngredients
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _cart_ID = "";
        private string _ingredient1 = "";
        private string _ingredient2 = "";
        private string _ingredient3 = "";

        public TempIngredients()
        {

        }

        public TempIngredients(string cart_ID, string ingredient1, string ingredient2, string ingredient3)
        {
            _cart_ID = cart_ID;
            _ingredient1 = ingredient1;
            _ingredient2 = ingredient2;
            _ingredient3 = ingredient3;
        }

        public string cartID
        {
            get { return _cart_ID; }
            set { _cart_ID = value; }
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

        public bool ingredientInsert()
        {
            bool ingredientExist = false;

            SqlConnection conn = new SqlConnection(_connStr);

            Debug.WriteLine("Checking if ingredients exist");
            try
            {
                string query = "SELECT cart_ID FROM TempIngredients WHERE cart_ID = @cart_ID";
                
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@cart_ID", this.cartID);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("Ingredients Exist!");
                        ingredientExist = true;

                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Ingredients do not exist!");
                    ingredientExist = false;
                    Debug.WriteLine(ex);
                }
                reader.Close();
                conn.Close();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Something went wrong reading tempIngredients");
                Debug.WriteLine(ex);
            }

            bool result = false;
            if (ingredientExist)
            {
                Debug.Write("UPDATING existing ingredients right now!");
                int rowsAffected = 0;
                string queryStr = "UPDATE TempIngredients SET ingredient1 = @ingredient_1, ingredient2 = @ingredient_2, ingredient3 = @ingredient_3 WHERE cart_ID = @cart_ID";
                
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@cart_ID", this.cartID);
                cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1);
                cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2);
                cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3);
                
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
                    return result;
                }
            }
            else
            {
                Debug.WriteLine("Writing to TempIngredients new ingredients now!");
                string queryStr = "INSERT INTO TempIngredients (cart_ID, ingredient1, ingredient2, ingredient3) VALUES (@cart_ID, @ingredient1, @ingredient2, @ingredient3)";

                SqlCommand cmd = new SqlCommand(queryStr, conn);

                int results = 0;
                cmd.Parameters.AddWithValue("@cart_ID", this.cartID);
                cmd.Parameters.AddWithValue("@ingredient1", this.ingredient1);
                cmd.Parameters.AddWithValue("@ingredient2", this.ingredient2);
                cmd.Parameters.AddWithValue("@ingredient3", this.ingredient3);
                Debug.WriteLine("Attempting to insert");
                conn.Open();
                results += cmd.ExecuteNonQuery();
                conn.Close();

                if (results > 0)
                {
                    Debug.WriteLine("Successfully added to TempIngredients");
                    result = true;
                    return result;
                }
                else
                {
                    Debug.WriteLine("Insert UNSUCCESSFUL!");
                    return result;
                }
            }
            
        }

        public DataTable ingredientRetrieve(string cart_ID)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            string queryStr = "SELECT ingredient1, ingredient2, ingredient3 FROM TempIngredients WHERE cart_ID = @cart_ID";
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@cart_ID", cart_ID);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            conn.Close();

            return dt;
        }

        public bool ingredientDeleteAll(string cart_ID)
        {
            SqlConnection conn = new SqlConnection(_connStr);

            int result = 0;
            string queryStr = "DELETE FROM TempIngredients WHERE cart_ID = @cart_ID";
            SqlCommand command = new SqlCommand(queryStr, conn);
            command.Parameters.AddWithValue("@cart_ID", cart_ID);
            conn.Open();
            result = command.ExecuteNonQuery();
            conn.Close();
            
            if (result > 0)
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