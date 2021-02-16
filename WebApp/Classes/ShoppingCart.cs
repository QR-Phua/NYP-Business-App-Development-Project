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
    public class ShoppingCart
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _cartID = null;
        private string _ingredient1 = string.Empty;
        private string _ingredient2 = string.Empty;
        private string _ingredient3 = string.Empty;
        private int _cleanserQuantity = 0;
        private int _tonerQuantity = 0;
        private int _moisturiserQuantity = 0;
        private string _cleanserBase = "" ;
        private string _tonerBase = "";
        private string _moisturiserBase = ""; 
        private int _frequency = -1;
        private string _result = "";

        
        public ShoppingCart()
        {
            _cartID = Guid.NewGuid().ToString();
        }

        public string result
        {
            get { return _result; }
            set { _result = value; }
        }

        public string cleanserBase
        {
            get { return _cleanserBase; }
            set { _cleanserBase = value; }
        }

        public string tonerBase
        {
            get { return _tonerBase; }
            set { _tonerBase = value; }
        }

        public string moisturiserBase
        {
            get { return _moisturiserBase; }
            set { _moisturiserBase = value; }
        }

        public int cleanserQuantity
        {
            get { return _cleanserQuantity; }
            set { _cleanserQuantity = value; }
        }
        public int tonerQuantity
        {
            get { return _tonerQuantity; }
            set { _tonerQuantity = value; }
        }
        public int moisturiserQuantity
        {
            get { return _moisturiserQuantity; }
            set { _moisturiserQuantity = value; }
        }
        public string cart_ID
        {
            get { return _cartID; }
            set { _cartID = value; }
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

        public int frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public bool UnsignedDeleteAllCartItem()
        {
            int rowsAffected = 0;
            string queryStr = "DELETE FROM UnsignedCartItem WHERE cart_ID = @cart_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");
                return true;
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool UnsignedDeleteCart()
        {
            int rowsAffected = 0;
            string queryStr = "DELETE FROM UnsignedCart WHERE cart_ID = @cart_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");
                return true;
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }


        public bool SignedDeleteAllCartItem()
        {
            int rowsAffected = 0;
            string queryStr = "DELETE FROM CartItem WHERE cart_ID = @cart_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");
                return true;
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool SignedDeleteCart()
        {
            int rowsAffected = 0;
            string queryStr = "DELETE FROM ShoppingCart WHERE cart_ID = @cart_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");
                return true;
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool SignedCartInsert(string custID)
        {
            //check if cart exists
            bool cartExist = false;
            Debug.WriteLine("Check if cart ID exists from unsignedCart Table");
            try
            {
                string queryStr = "SELECT cart_ID FROM ShoppingCart WHERE (cust_ID = @cust_ID AND cart_ID = @cart_ID)";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@cust_ID", custID);
                cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("Signed cart Exist!");
                        cartExist = true;

                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Signed Cart do not exist!");
                    cartExist = false;
                    Debug.WriteLine(ex);
                }
                reader.Close();
                conn.Close();

            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Something went wrong reading ShoppingCart");
                Debug.WriteLine(ex);
            }

            Debug.WriteLine("If cart Exist checking for item in CartItem table");

            //IF CART EXISTS THIS PATH
            if (cartExist)
            {
                Debug.Write("UPDATING existing cart right now!");
                int rowsAffected = 0;
                string queryStr = "UPDATE ShoppingCart SET ingredient_1 = @ingredient_1, ingredient_2 = @ingredient_2, ingredient_3 = @ingredient_3, frequency = @frequency  WHERE (cart_ID = @cart_ID AND cust_ID = @cust_ID)";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1.ToString());
                cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2.ToString());
                cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3.ToString());
                cmd.Parameters.AddWithValue("@frequency", this.frequency);
                cmd.Parameters.AddWithValue("@cust_ID", custID);
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    Debug.WriteLine("Existing Cart updated successfully!");
                    int deleted = 0;
                    Debug.WriteLine("Deleting ALL cart items!");
                    string queryString = "DELETE FROM CartItem WHERE cart_ID = @cart_ID";
                    SqlConnection con = new SqlConnection(_connStr);
                    SqlCommand command2 = new SqlCommand(queryString, con);
                    command2.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                    con.Open();
                    deleted = command2.ExecuteNonQuery();
                    con.Close();

                    if (deleted > 0)
                    {
                        Debug.WriteLine("SUCCESSFULLY DELETED cart items!");
                        bool cleanserStatus = false;
                        bool tonerStatus = false;
                        bool moisturiserStatus = false;
                        bool cleanser = false;
                        bool toner = false;
                        bool moisturiser = false;
                        if (this.cleanserQuantity > 0)
                        {
                            cleanser = true;
                        }
                        else
                        {
                            cleanserStatus = true;
                        }

                        if (this.tonerQuantity > 0)
                        {
                            toner = true;

                        }
                        else
                        {
                            tonerStatus = true;
                        }

                        if (this.moisturiserQuantity > 0)
                        {
                            moisturiser = true;
                        }
                        else
                        {
                            moisturiserStatus = true;
                        }

                        int cleanserPos = 0;
                        int tonerPos = 0;
                        int moisturiserPos = 0;
                        if (cleanser == true && toner != true && moisturiser != true)
                        {
                            cleanserPos = 1;
                        }
                        else if (cleanser == true && toner == true && moisturiser != true)
                        {
                            cleanserPos = 1;
                            tonerPos = 2;
                        }

                        else if (cleanser == true && toner != true && moisturiser == true)
                        {
                            cleanserPos = 1;
                            moisturiserPos = 2;
                        }

                        else if (cleanser == true && toner == true && moisturiser == true)
                        {
                            cleanserPos = 1;
                            tonerPos = 2;
                            moisturiserPos = 3;
                        }

                        else if (cleanser != true && toner == true && moisturiser != true)
                        {
                            tonerPos = 1;
                        }

                        else if (cleanser != true && toner == true && moisturiser == true)
                        {
                            tonerPos = 1;
                            moisturiserPos = 2;
                        }

                        else if (cleanser != true && toner != true && moisturiser == true)
                        {
                            moisturiserPos = 1;
                        }
                        Debug.WriteLine("Completed assigning of variables");
                        Debug.Write("Checking if Cleanser was selected");

                        //insert cleanser if have
                        int cleanserResult = 0;
                        if (cleanser)
                        {
                            Debug.WriteLine("Cleanser exists! writing into db");
                            string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", cleanserPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.cleanserBase);
                                command.Parameters.AddWithValue("@quantity", this.cleanserQuantity);
                                command.Parameters.AddWithValue("@type", "Cleanser");
                                command.Parameters.AddWithValue("@price", 19.00);
                                connStr.Open();
                                cleanserResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (cleanserResult > 0)
                                {
                                    cleanserStatus = true;
                                    Debug.WriteLine("Added it Succesfully");
                                }
                                else
                                {
                                    Debug.WriteLine("Unsuccessful adding it ");
                                }
                            }
                            catch (SqlException ex)
                            {
                                Debug.WriteLine("Someething went wrong at Cleanser Cart Item");
                                Debug.WriteLine(ex);
                            }
                        }

                        // insert toner if have
                        int tonerResult = 0;
                        if (toner)
                        {
                            Debug.WriteLine("ADDING Toner into existing cart!");
                            string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", tonerPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.tonerBase);
                                command.Parameters.AddWithValue("@quantity", this.tonerQuantity);
                                command.Parameters.AddWithValue("@type", "Toner-Serum");
                                command.Parameters.AddWithValue("@price", 29.00);
                                connStr.Open();
                                tonerResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (tonerResult > 0)
                                {
                                    Debug.WriteLine("Toner added SUCCESSFULLY!");
                                    tonerStatus = true;
                                }
                                else
                                {
                                    Debug.WriteLine("Toner added UNSUCCESSFULLY!");
                                }

                            }
                            catch (SqlException ex)
                            {
                                Debug.WriteLine("Something went wrong adding Toner to table! Error below");
                                Debug.WriteLine(ex);
                            }
                        }

                        int moisturiserResult = 0;
                        if (moisturiser)
                        {
                            Debug.WriteLine("ADDING Moisturiser to existing cart!");
                            string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", moisturiserPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.moisturiserBase);
                                command.Parameters.AddWithValue("@quantity", this.moisturiserQuantity);
                                command.Parameters.AddWithValue("@type", "Moisturiser");
                                command.Parameters.AddWithValue("@price", 29.00);
                                connStr.Open();
                                moisturiserResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (moisturiserResult > 0)
                                {
                                    Debug.WriteLine("Moisturiser added SUCCESSFULLY!");
                                    moisturiserStatus = true;
                                }
                                else
                                {
                                    Debug.WriteLine("Mosituriser added UNSUCCESSFULLY!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Something went wrong adding moisturiser to table! Error below");
                                Debug.WriteLine(ex);
                            }
                        }

                        //Check if all inserted correctly!

                        if (cleanserStatus && tonerStatus && moisturiserStatus)
                        {
                            bool result = true;
                            return result;
                        }
                        else
                        {
                            bool result = false;
                            return result;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("ERROR DELETING EXISTING CART ITEMS!");
                        return false;
                    }

                }
                else
                {
                    Debug.WriteLine("ERROR UPDATING EXISTING CART!");
                    return false;
                }
            }

            //IF CART DONT EXIST THIS PATH
            else
            {
                Debug.WriteLine("Cart Does not Exist!");
                Debug.WriteLine("Prepping for insert");
                // string msg = null;
                bool result = false;

                string queryStr = "INSERT INTO ShoppingCart(cart_ID,ingredient_1,ingredient_2,ingredient_3,frequency,cust_ID)"
                    + " values (@cart_ID,@ingredient_1,@ingredient_2,@ingredient_3,@frequency,@cust_ID)";

                try
                {
                    Debug.WriteLine("Attempting to add cart");
                    int firstInsert = 0;
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                    cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1);
                    cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2);
                    cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3);
                    cmd.Parameters.AddWithValue("@frequency", this.frequency);
                    cmd.Parameters.AddWithValue("@cust_ID", custID);

                    conn.Open();
                    firstInsert += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                    conn.Close();

                    if (firstInsert > 0)
                    {
                        Debug.WriteLine("Cart Added Successfully");
                        result = true;
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Something went wrong adding cart. Error below");
                    Debug.WriteLine(ex);
                }


                if (result)
                {
                    Debug.WriteLine("Adding items to CartItem now!");
                    bool cleanserStatus = false;
                    bool tonerStatus = false;
                    bool moisturiserStatus = false;
                    bool cleanser = false;
                    bool toner = false;
                    bool moisturiser = false;
                    if (this.cleanserQuantity > 0)
                    {
                        cleanser = true;
                    }
                    else
                    {
                        cleanserStatus = true;
                    }

                    if (this.tonerQuantity > 0)
                    {
                        toner = true;

                    }
                    else
                    {
                        tonerStatus = true;
                    }

                    if (this.moisturiserQuantity > 0)
                    {
                        moisturiser = true;
                    }
                    else
                    {
                        moisturiserStatus = true;
                    }

                    int cleanserPos = 0;
                    int tonerPos = 0;
                    int moisturiserPos = 0;
                    if (cleanser == true && toner != true && moisturiser != true)
                    {
                        cleanserPos = 1;
                    }
                    else if (cleanser == true && toner == true && moisturiser != true)
                    {
                        cleanserPos = 1;
                        tonerPos = 2;
                    }

                    else if (cleanser == true && toner != true && moisturiser == true)
                    {
                        cleanserPos = 1;
                        moisturiserPos = 2;
                    }

                    else if (cleanser == true && toner == true && moisturiser == true)
                    {
                        cleanserPos = 1;
                        tonerPos = 2;
                        moisturiserPos = 3;
                    }

                    else if (cleanser != true && toner == true && moisturiser != true)
                    {
                        tonerPos = 1;
                    }

                    else if (cleanser != true && toner == true && moisturiser == true)
                    {
                        tonerPos = 1;
                        moisturiserPos = 2;
                    }

                    else if (cleanser != true && toner != true && moisturiser == true)
                    {
                        moisturiserPos = 1;
                    }

                    Debug.WriteLine("Finish assigning variables");
                    Debug.WriteLine("Checking if Cleanser exists");
                    //insert cleanser if have
                    int cleanserResult = 0;
                    if (cleanser)
                    {
                        Debug.WriteLine("cleanser exists! adding to table");
                        string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", cleanserPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.cleanserBase);
                            cmd.Parameters.AddWithValue("@quantity", this.cleanserQuantity);
                            cmd.Parameters.AddWithValue("@type", "Cleanser");
                            cmd.Parameters.AddWithValue("@price", 19.00);
                            conn.Open();
                            cleanserResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (cleanserResult > 0)
                            {
                                Debug.WriteLine("Cleanser added SUCCESSFULLY!");
                                cleanserStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Cleanser added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Something went wrong adding cleanser to table! Error below");
                            Debug.WriteLine(ex);
                        }
                    }

                    // insert toner if have
                    int tonerResult = 0;
                    Debug.WriteLine("Checking If toner exists");
                    if (toner)
                    {
                        Debug.WriteLine("Toner Exists!");
                        string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", tonerPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.tonerBase);
                            cmd.Parameters.AddWithValue("@quantity", this.tonerQuantity);
                            cmd.Parameters.AddWithValue("@type", "Toner-Serum");
                            cmd.Parameters.AddWithValue("@price", 29.00);
                            conn.Open();
                            tonerResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (tonerResult > 0)
                            {
                                Debug.WriteLine("Toner added successfully!");
                                tonerStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Toner added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Something went wrong adding toner! Error below!");
                            Debug.WriteLine(ex);
                        }
                    }

                    int moisturiserResult = 0;
                    Debug.WriteLine("Checking if moisturiser exists");
                    if (moisturiser)
                    {
                        Debug.WriteLine("Moisturiser exists!");
                        string query = "INSERT INTO CartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", moisturiserPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.moisturiserBase);
                            cmd.Parameters.AddWithValue("@quantity", this.moisturiserQuantity);
                            cmd.Parameters.AddWithValue("@type", "Moisturiser");
                            cmd.Parameters.AddWithValue("@price", 29.00);
                            conn.Open();
                            moisturiserResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (moisturiserResult > 0)
                            {
                                Debug.WriteLine("Successfully aded Moisturiser!");
                                moisturiserStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Moisturiser added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Somethiing went wrong adding mosituriser to table! error below");
                            Debug.WriteLine(ex);
                        }
                    }

                    if (cleanserStatus && tonerStatus && moisturiserStatus)
                    {
                        Debug.WriteLine("COMPLETED ALL INSERTS TO UNSIGNED CART TABLE FOR CART THAT DONT EXISTS!");
                        result = true;
                        return result;
                    }
                    else
                    {
                        Debug.WriteLine("NOT ALL INSERTS COMPLETED TO UNSIGNED CART");
                        result = false;
                        return result;
                    }

                }
                else
                {
                    Debug.WriteLine("COULD NOT ADD CART TO UNSIGNEDCART TABLE");
                    return result;
                }
            }

        }

        public bool SignedCartDelete(string type)
        {
            
            int rowsAffected = 0;

            string queryStr = "DELETE FROM CartItem WHERE (cart_ID = @cart_ID AND type = @type)";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            Debug.WriteLine("BEGIN DELETING ");
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            cmd.Parameters.AddWithValue("@type", type);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");
                return true;
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool SignedCartUpdate(string type, int quantity)
        {
            SqlConnection conn = new SqlConnection(_connStr);

            int rowsAffected = 0;
            string queryStr = "UPDATE CartItem SET quantity = @quantity WHERE (cart_ID = @cart_ID AND type = @type)";
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            Debug.WriteLine("BEGIN UPDATING ");
            cmd.Parameters.AddWithValue("@cart_ID", cart_ID);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            Debug.WriteLine("BEGIN UPDATING!");
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("UPDATE SUCCESSFUL!");
                return true;
            }
            else
            {
                Debug.WriteLine("UPDATE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool CartInsert()
        {
            //check if cart exists
            bool cartExist = false;
            Debug.WriteLine("Check if cart ID exists from unsignedCart Table");
            try
            {
                string queryStr = "SELECT cart_ID FROM UnsignedCart WHERE cart_ID = @cart_ID";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        Debug.WriteLine("cart Exist!");
                        cartExist = true;
                        
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Cart do not exist!");
                    cartExist = false;
                    Debug.WriteLine(ex);
                }
                reader.Close();
                conn.Close();

            } catch (SqlException ex) 
            {
                Debug.WriteLine("Something went wrong reading UnsignedCart");
                Debug.WriteLine(ex);
            }

            Debug.WriteLine("If cart Exist checking for item in UnsignedCartItem table");

            //IF CART EXISTS THIS PATH
            if (cartExist)
            {
                Debug.Write("UPDATING existing cart right now!");
                int rowsAffected = 0;
                string queryStr = "UPDATE UnsignedCart SET ingredient_1 = @ingredient_1, ingredient_2 = @ingredient_2, ingredient_3 = @ingredient_3, frequency = @frequency  WHERE cart_ID = @cart_ID";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1.ToString());
                cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2.ToString());
                cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3.ToString());
                cmd.Parameters.AddWithValue("@frequency", this.frequency);
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    Debug.WriteLine("Existing Cart updated successfully!");
                    int deleted = 0;
                    Debug.WriteLine("Deleting ALL cart items!");
                    string queryString = "DELETE FROM UnsignedCartItem WHERE cart_ID = @cart_ID";
                    SqlConnection con = new SqlConnection(_connStr);
                    SqlCommand command2 = new SqlCommand(queryString, con);
                    command2.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                    con.Open();
                    deleted = command2.ExecuteNonQuery();
                    con.Close();

                    if (deleted > 0)
                    {
                        Debug.WriteLine("SUCCESSFULLY DELETED cart items!");
                        bool cleanserStatus = false;
                        bool tonerStatus = false;
                        bool moisturiserStatus = false;
                        bool cleanser = false;
                        bool toner = false;
                        bool moisturiser = false;

                                                
                        if (this.cleanserQuantity > 0)
                        {
                            cleanser = true;
                        }
                        else
                        {
                            cleanserStatus = true;
                        }

                        if (this.tonerQuantity > 0)
                        {
                            toner = true;
                            
                        }
                        else
                        {
                            tonerStatus = true;
                        }

                        if (this.moisturiserQuantity > 0)
                        {
                            moisturiser = true;
                        }
                        else
                        {
                            moisturiserStatus = true;
                        }

                        int cleanserPos = 0;
                        int tonerPos = 0;
                        int moisturiserPos = 0;
                        if (cleanser == true && toner != true && moisturiser != true)
                        {
                            cleanserPos = 1;
                        }
                        else if (cleanser == true && toner == true && moisturiser != true)
                        {
                            cleanserPos = 1;
                            tonerPos = 2;
                        }

                        else if (cleanser == true && toner != true && moisturiser == true)
                        {
                            cleanserPos = 1;
                            moisturiserPos = 2;
                        }

                        else if (cleanser == true && toner == true && moisturiser == true)
                        {
                            cleanserPos = 1;
                            tonerPos = 2;
                            moisturiserPos = 3;
                        }

                        else if (cleanser != true && toner == true && moisturiser != true)
                        {
                            tonerPos = 1;
                        }

                        else if (cleanser != true && toner == true && moisturiser == true)
                        {
                            tonerPos = 1;
                            moisturiserPos = 2;
                        }

                        else if (cleanser != true && toner != true && moisturiser == true)
                        {
                            moisturiserPos = 1;
                        }

                        

                        Debug.WriteLine("Completed assigning of variables");
                        Debug.Write("Checking if Cleanser was selected");

                        //insert cleanser if have
                        int cleanserResult = 0;
                        if (cleanser)
                        {
                            Debug.WriteLine("Cleanser exists! writing into db");
                            string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", cleanserPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.cleanserBase);
                                command.Parameters.AddWithValue("@quantity", this.cleanserQuantity);
                                command.Parameters.AddWithValue("@type", "Cleanser");
                                command.Parameters.AddWithValue("@price", 19.00);
                                connStr.Open();
                                cleanserResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (cleanserResult > 0)
                                {
                                    cleanserStatus = true;
                                    Debug.WriteLine("Added it Succesfully");
                                }
                                else
                                {
                                    Debug.WriteLine("Unsuccessful adding it ");
                                }
                            }
                            catch (SqlException ex)
                            {
                                Debug.WriteLine("Someething went wrong at Cleanser Unsigned Cart Item");
                                Debug.WriteLine(ex);
                            }
                        }

                        // insert toner if have
                        int tonerResult = 0;
                        if (toner)
                        {
                            Debug.WriteLine("ADDING Toner into existing cart!");
                            string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", tonerPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.tonerBase);
                                command.Parameters.AddWithValue("@quantity", this.tonerQuantity);
                                command.Parameters.AddWithValue("@type", "Toner-Serum");
                                command.Parameters.AddWithValue("@price", 29.00);
                                connStr.Open();
                                tonerResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (tonerResult > 0)
                                {
                                    Debug.WriteLine("Toner added SUCCESSFULLY!");
                                    tonerStatus = true;
                                }
                                else
                                {
                                    Debug.WriteLine("Toner added UNSUCCESSFULLY!");
                                }

                            }
                            catch (SqlException ex)
                            {
                                Debug.WriteLine("Something went wrong adding Toner to table! Error below");
                                Debug.WriteLine(ex);
                            }
                        }

                        int moisturiserResult = 0;
                        if (moisturiser)
                        {
                            Debug.WriteLine("ADDING Moisturiser to existing cart!");
                            string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                            + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                            try
                            {
                                SqlConnection connStr = new SqlConnection(_connStr);
                                SqlCommand command = new SqlCommand(query, connStr);
                                command.Parameters.AddWithValue("@item_ID", moisturiserPos);
                                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                                command.Parameters.AddWithValue("@baseIngredient", this.moisturiserBase);
                                command.Parameters.AddWithValue("@quantity", this.moisturiserQuantity);
                                command.Parameters.AddWithValue("@type", "Moisturiser");
                                command.Parameters.AddWithValue("@price", 29.00);
                                connStr.Open();
                                moisturiserResult += command.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                                connStr.Close();

                                if (moisturiserResult > 0)
                                {
                                    Debug.WriteLine("Moisturiser added SUCCESSFULLY!");
                                    moisturiserStatus = true;
                                }
                                else
                                {
                                    Debug.WriteLine("Mosituriser added UNSUCCESSFULLY!");
                                }

                            }
                            catch (SqlException ex)
                            {
                                Debug.WriteLine("Something went wrong adding moisturiser to table! Error below");
                                Debug.WriteLine(ex);
                            }
                        }

                        //Check if all inserted correctly!

                        if (cleanserStatus && tonerStatus && moisturiserStatus)
                        {
                            bool result = true;
                            return result;
                        }
                        else
                        {
                            bool result = false;
                            return result;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("ERROR DELETING EXISTING CART ITEMS!");
                        return false;
                    }
                    
                }
                else
                {
                    Debug.WriteLine("ERROR UPDATING EXISTING CART!");
                    return false;
                }
            }

            //IF CART DONT EXIST THIS PATH
            else {
                Debug.WriteLine("Cart Does not Exist!");
                Debug.WriteLine("Prepping for insert");
                // string msg = null;
                bool result = false;

                string queryStr = "INSERT INTO UnsignedCart(cart_ID,ingredient_1,ingredient_2,ingredient_3,frequency)"
                    + " values (@cart_ID,@ingredient_1,@ingredient_2,@ingredient_3,@frequency)";

                try 
                {
                    Debug.WriteLine("Attempting to add cart");
                    int firstInsert = 0;
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                    cmd.Parameters.AddWithValue("@ingredient_1", this.ingredient1);
                    cmd.Parameters.AddWithValue("@ingredient_2", this.ingredient2) ;
                    cmd.Parameters.AddWithValue("@ingredient_3", this.ingredient3);
                    cmd.Parameters.AddWithValue("@frequency", this.frequency);

                    conn.Open();
                    firstInsert += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                    conn.Close();

                    if (firstInsert > 0)
                    {
                        Debug.WriteLine("Cart Added Successfully");
                        result = true;
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("Something went wrong adding cart. Error below");
                    Debug.WriteLine(ex);
                }


                if (result)
                {
                    Debug.WriteLine("Adding items to UnsignedCartItem now!");
                    bool cleanserStatus = false;
                    bool tonerStatus = false;
                    bool moisturiserStatus = false;
                    bool cleanser = false;
                    bool toner = false;
                    bool moisturiser = false;

                    if (this.cleanserQuantity > 0)
                    {
                        cleanser = true;
                    }
                    else
                    {
                        cleanserStatus = true;
                    }

                    if (this.tonerQuantity > 0)
                    {
                        toner = true;

                    }
                    else
                    {
                        tonerStatus = true;
                    }

                    if (this.moisturiserQuantity > 0)
                    {
                        moisturiser = true;
                    }
                    else
                    {
                        moisturiserStatus = true;
                    }

                    int cleanserPos = 0;
                    int tonerPos = 0;
                    int moisturiserPos = 0;
                    if (cleanser == true && toner != true && moisturiser != true)
                    {
                        cleanserPos = 1;
                    }
                    else if (cleanser == true && toner == true && moisturiser != true)
                    {
                        cleanserPos = 1;
                        tonerPos = 2;
                    }

                    else if (cleanser == true && toner != true && moisturiser == true)
                    {
                        cleanserPos = 1;
                        moisturiserPos = 2;
                    }

                    else if (cleanser == true && toner == true && moisturiser == true)
                    {
                        cleanserPos = 1;
                        tonerPos = 2;
                        moisturiserPos = 3;
                    }

                    else if (cleanser != true && toner == true && moisturiser != true)
                    {
                        tonerPos = 1;
                    }

                    else if (cleanser != true && toner == true && moisturiser == true)
                    {
                        tonerPos = 1;
                        moisturiserPos = 2;
                    }

                    else if (cleanser != true && toner != true && moisturiser == true)
                    {
                        moisturiserPos = 1;
                    }

                    Debug.WriteLine("Finish assigning variables");
                    Debug.WriteLine("Checking if Cleanser exists");
                    //insert cleanser if have
                    int cleanserResult = 0;
                    if (cleanser) {
                        Debug.WriteLine("cleanser exists! adding to table");
                        string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", cleanserPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.cleanserBase);
                            cmd.Parameters.AddWithValue("@quantity", this.cleanserQuantity);
                            cmd.Parameters.AddWithValue("@type", "Cleanser");
                            cmd.Parameters.AddWithValue("@price", 19.00);
                            conn.Open();
                            cleanserResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (cleanserResult > 0)
                            {
                                Debug.WriteLine("Cleanser added SUCCESSFULLY!");
                                cleanserStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Cleanser added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Something went wrong adding cleanser to table! Error below");
                            Debug.WriteLine(ex);
                        }
                    }

                    // insert toner if have
                    int tonerResult = 0;
                    Debug.WriteLine("Checking If toner exists");
                    if (toner)
                    {
                        Debug.WriteLine("Toner Exists!");
                        string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", tonerPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.tonerBase);
                            cmd.Parameters.AddWithValue("@quantity", this.tonerQuantity);
                            cmd.Parameters.AddWithValue("@type", "Toner-Serum");
                            cmd.Parameters.AddWithValue("@price", 29.00);
                            conn.Open();
                            tonerResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (tonerResult > 0)
                            {
                                Debug.WriteLine("Toner added successfully!");
                                tonerStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Toner added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Something went wrong adding toner! Error below!");
                            Debug.WriteLine(ex);
                        }
                    }

                    int moisturiserResult = 0;
                    Debug.WriteLine("Checking if moisturiser exists");
                    if (moisturiser)
                    {
                        Debug.WriteLine("Moisturiser exists!");
                        string query = "INSERT INTO UnsignedCartItem(item_ID,cart_ID,baseIngredient,quantity,type,price)"
                        + " values (@item_ID,@cart_ID,@baseIngredient,@quantity,@type,@price)";
                        try
                        {
                            SqlConnection conn = new SqlConnection(_connStr);
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@item_ID", moisturiserPos);
                            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                            cmd.Parameters.AddWithValue("@baseIngredient", this.moisturiserBase);
                            cmd.Parameters.AddWithValue("@quantity", this.moisturiserQuantity);
                            cmd.Parameters.AddWithValue("@type", "Moisturiser");
                            cmd.Parameters.AddWithValue("@price", 29.00);
                            conn.Open();
                            moisturiserResult += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                            conn.Close();

                            if (moisturiserResult > 0)
                            {
                                Debug.WriteLine("Successfully aded Moisturiser!");
                                moisturiserStatus = true;
                            }
                            else
                            {
                                Debug.WriteLine("Moisturiser added UNSUCCESSFULLY!");
                            }

                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine("Somethiing went wrong adding mosituriser to table! error below");
                            Debug.WriteLine(ex);
                        }
                    }

                    if (cleanserStatus && tonerStatus && moisturiserStatus)
                    {
                        Debug.WriteLine("COMPLETED ALL INSERTS TO UNSIGNED CART TABLE FOR CART THAT DONT EXISTS!");
                        result = true;
                        return result;
                    }
                    else
                    {
                        Debug.WriteLine("NOT ALL INSERTS COMPLETED TO UNSIGNED CART");
                        result = false;
                        return result;
                    }

                }
                else
                {
                    Debug.WriteLine("COULD NOT ADD CART TO UNSIGNEDCART TABLE");
                    return result;
                }
            }
            
        }

        public bool CartDelete(string type)
        {
            SqlConnection conn = new SqlConnection(_connStr);

            int rowsAffected = 0;

            string queryStr = "DELETE FROM UnsignedCartItem WHERE (cart_ID = @cart_ID AND type = @type)";
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            Debug.WriteLine("BEGIN DELETING ");
            cmd.Parameters.AddWithValue("@cart_ID", this.cart_ID);
            cmd.Parameters.AddWithValue("@type", type);
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("DELETE FROM CLASS METHOD SUCCESSFUL! ");

                int deletedRows = 0;

                // check if cart is empty now 
                string query = "SELECT * FROM UnsignedCartItem WHERE cart_ID = @cart_ID";
                SqlCommand command = new SqlCommand(query, conn);
                Debug.WriteLine("Query database to see if there is anything");

                command.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                conn.Open();

                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    conn.Close();
                    string query1 = "DELETE FROM UnsignedCart WHERE cart_ID = @cart_ID";
                    SqlCommand command2 = new SqlCommand(query1, conn);

                    Debug.WriteLine("BEGIN DELETING CART FROM DB");
                    command2.Parameters.AddWithValue("@cart_ID", this.cart_ID);
                    conn.Open();
                    deletedRows = command2.ExecuteNonQuery();
                    conn.Close();

                    if (deletedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                                
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
                return false;
            }
        }

        public bool CartUpdate(string type, int quantity)
        {
            SqlConnection conn = new SqlConnection(_connStr);

            int rowsAffected = 0;
            string queryStr = "UPDATE UnsignedCartItem SET quantity = @quantity WHERE (cart_ID = @cart_ID AND type = @type)";
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            Debug.WriteLine("BEGIN UPDATING ");
            cmd.Parameters.AddWithValue("@cart_ID", cart_ID);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@quantity", quantity);

            Debug.WriteLine("BEGIN UPDATING!");
            conn.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                Debug.WriteLine("UPDATE SUCCESSFUL!");
                return true;
            }
            else
            {
                Debug.WriteLine("UPDATE UNSUCCESSFUL! ");
                return false;
            }
        }

        public DataTable IngredientPageRetrieve() //Shopping Cart Page 
        {
            SqlConnection conn = new SqlConnection(_connStr);

            conn.Open();
            string query = "SELECT type, price, quantity FROM UnsignedCartItem WHERE cart_ID = @cart_ID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cart_ID", cart_ID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable SignedIngredientPageRetrieve()
        {
            SqlConnection conn = new SqlConnection(_connStr);

            conn.Open();
            string query = "SELECT type, price, quantity FROM CartItem WHERE cart_ID = @cart_ID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cart_ID", cart_ID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }


        public DataTable IngredientListRetrieve(string skinType, string sensitivity ,string concern_Type1, string concern_Type2, int level, string type )
        {
            SqlConnection conn = new SqlConnection(_connStr);

            string queryStr;
            if (sensitivity == "Yes")
            {
                queryStr = "SELECT ingredient_Name, description, quantity FROM Ingredient WHERE ((skinType = @SkinType OR skinType = 'All' )" +
                " AND sensitivity = 'Yes' AND (concern_Type = @concern_Type1 OR concern_Type = @concern_Type2 OR concern_type ='All')" +
                " AND level <= @level AND type = @type)";

            }
            else
            {
                queryStr = "SELECT ingredient_Name, description, quantity FROM Ingredient WHERE ((skinType = @SkinType OR skinType = 'All' )" +
                " AND (sensitivity = 'Yes' or sensitivity = 'No') AND (concern_Type = @concern_Type1 OR concern_Type = @concern_Type2 OR concern_type ='All')" +
                " AND level <= @level AND type = @type)";
            }

            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@SkinType", skinType);
            cmd.Parameters.AddWithValue("@concern_Type1", concern_Type1);
            cmd.Parameters.AddWithValue("@concern_Type2", concern_Type2);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@type", type);


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable TableData = new DataTable();
            TableData.Clear();
            TableData.Columns.Add("Ingredient_Name");
            TableData.Columns.Add("Description");
            TableData.Columns.Add("Quantity");
            sda.Fill(TableData);

            foreach (DataRow row in TableData.Rows)
            {
                Debug.WriteLine(row["Ingredient_Name"].ToString());
            }

            return TableData;
        }

        
    }

} 

    
