 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AdminApp
{
    public class Ingredient
    {
        string _connStr = ConfigurationManager.ConnectionStrings["WebAppDB"].ConnectionString;
        private string _ingredient_ID = "";
        private string _ingredient_Name = "";
        private string _suppl_ID = "";
        private string _suppl_Name = "";
        private string _description = "";
        private int _quantity = 0;
        private decimal _cost_Price = 0;
        private decimal _sale_Price = 0;
        private int _level = 0;
        private string _concern_Type = "";
        private string _skin_Type = "";
        private string _sensitivity = "";
        private string _type = "";



        public Ingredient()
        {
        }
        public Ingredient(string ingredient_ID, string ingredient_Name, string suppl_ID, string suppl_Name, string description,
               int quantity, decimal cost_Price, decimal sale_Price, int level, string concern_Type, string skin_Type,
               string sensitivity, string type)
        {
            _ingredient_ID = ingredient_ID;
            _ingredient_Name = ingredient_Name;
            _suppl_ID = suppl_ID;
            _suppl_Name = suppl_Name;
            _description = description;
            _quantity = quantity;
            _cost_Price = cost_Price;
            _sale_Price = sale_Price;
            _level = level;
            _concern_Type = concern_Type;
            _skin_Type = skin_Type;
            _sensitivity = sensitivity;
            _type = type;
        }

        //public Ingredient(string ingredient_Name, string suppl_ID, int quantity)
        //{

        //    _ingredient_Name = ingredient_Name;
        //    _suppl_ID = suppl_ID;
        //    _quantity = quantity;
        //}


        // Constructor that take in all except Ingredient ID
        public Ingredient(string ingredient_Name, string suppl_ID, string suppl_Name, string description,
                int quantity, decimal cost_Price, decimal sale_Price, int level, string concern_Type,
                string skin_Type, string sensitivity, string type)
            : this(null, ingredient_Name, suppl_ID, suppl_Name, description, quantity, cost_Price,
                  sale_Price, level, concern_Type, skin_Type, sensitivity, type)
        {
        }

        // Constructor that take in only Ingredient ID. The other attributes will be set to 0 or empty.
        public Ingredient(string ingredient_ID)
            : this(ingredient_ID, "", "", "", "", 0, 0, 0, 0, "", "", "", "")
        {
        }

        public string ingredient_ID
        {
            get { return _ingredient_ID; }
            set { _ingredient_ID = value; }
        }

        public string ingredient_Name
        {
            get { return _ingredient_Name; }
            set { _ingredient_Name = value; }
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
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public decimal cost_Price
        {
            get { return _cost_Price; }
            set { _cost_Price = value; }
        }

        public decimal sale_Price
        {
            get { return _sale_Price; }
            set { _sale_Price = value; }
        }

        public int level
        {
            get { return _level; }
            set { _level = value; }
        }
        public string concern_Type
        {
            get { return _concern_Type; }
            set { _concern_Type = value; }
        }

        public string skin_Type
        {
            get { return _skin_Type; }
            set { _skin_Type = value; }
        }

        public string sensitivity
        {
            get { return _sensitivity; }
            set { _sensitivity = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        // class methods

        public Ingredient getIngredient(string ingredient_ID)
        {
            Ingredient ingredientDetail = null;

            string ingredient_Name, suppl_ID, suppl_Name, description,
                concern_Type, skin_Type, sensitivity, type;
            decimal cost_Price, sale_Price;
            int quantity, level;

            string queryStr = "SELECT * FROM Ingredient WHERE Ingredient_ID = @IngredientID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@IngredientID", ingredient_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ingredient_Name = dr["ingredient_Name"].ToString();
                suppl_ID = dr["suppl_ID"].ToString();
                suppl_Name = dr["suppl_Name"].ToString();
                description = dr["description"].ToString();
                quantity = int.Parse(dr["quantity"].ToString());
                cost_Price = decimal.Parse(dr["cost_Price"].ToString());
                sale_Price = decimal.Parse(dr["sale_Price"].ToString());
                level = int.Parse(dr["level"].ToString());
                concern_Type = dr["concern_Type"].ToString();
                skin_Type = dr["skin_Type"].ToString();
                sensitivity = dr["sensitivity"].ToString();
                type = dr["type"].ToString();

                ingredientDetail = new Ingredient(ingredient_ID, ingredient_Name, suppl_ID, suppl_Name, description, quantity, cost_Price,
                  sale_Price, level, concern_Type, skin_Type, sensitivity, type);
            }
            else
            {
                ingredientDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return ingredientDetail;

        }


        public List<Ingredient> getIngredientAll()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();

            string ingredient_ID, ingredient_Name, suppl_ID, suppl_Name, description, concern_Type, skin_Type, sensitivity, type;
            decimal cost_Price, sale_Price;
            int quantity, level;

            string queryStr = "SELECT * FROM Ingredient Order By Ingredient_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ingredient_ID = dr["ingredient_ID"].ToString();
                ingredient_Name = dr["ingredient_Name"].ToString();
                suppl_ID = dr["suppl_ID"].ToString();
                suppl_Name = dr["suppl_Name"].ToString();
                description = dr["description"].ToString();
                quantity = int.Parse(dr["quantity"].ToString());
                cost_Price = decimal.Parse(dr["cost_Price"].ToString());
                sale_Price = decimal.Parse(dr["sale_Price"].ToString());
                level = int.Parse(dr["level"].ToString());
                concern_Type = dr["concern_Type"].ToString();
                skin_Type = dr["skinType"].ToString();
                sensitivity = dr["sensitivity"].ToString();
                type = dr["type"].ToString();

                Ingredient a = new Ingredient(ingredient_ID, ingredient_Name, suppl_ID, suppl_Name, description, quantity, cost_Price,
                  sale_Price, level, concern_Type, skin_Type, sensitivity, type);
                ingredientList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return ingredientList;
        }


        // INSERT
        public int IngredientInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Ingredient(ingredient_ID, ingredient_Name, suppl_ID, suppl_Name, description, quantity, cost_Price, sale_Price, level, concern_Type, skinType, sensitivity, type)"
                + " values (@ingredient_ID, @ingredient_Name, @suppl_ID, @suppl_Name, @description, @quantity, @cost_Price, @sale_Price, @level, @concern_Type, @skin_Type, @sensitivity, @type)";
            //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ingredient_ID", this._ingredient_ID);
            cmd.Parameters.AddWithValue("@ingredient_Name", this._ingredient_Name);
            cmd.Parameters.AddWithValue("@suppl_ID", this._suppl_ID);
            cmd.Parameters.AddWithValue("@suppl_Name", this._suppl_Name);
            cmd.Parameters.AddWithValue("@description", this._description);
            cmd.Parameters.AddWithValue("@quantity", this._quantity);
            cmd.Parameters.AddWithValue("@cost_Price", this._cost_Price);
            cmd.Parameters.AddWithValue("@sale_Price", this._sale_Price);
            cmd.Parameters.AddWithValue("@level", this._level);
            cmd.Parameters.AddWithValue("@concern_Type", this._concern_Type);
            cmd.Parameters.AddWithValue("@skin_Type", this._skin_Type);
            cmd.Parameters.AddWithValue("@sensitivity", this.sensitivity);
            cmd.Parameters.AddWithValue("@type", this.type);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert


        // DELETE
        public int IngredientDelete(string ID)
        {
            string queryStr = "DELETE FROM Ingredient WHERE ingredient_ID=@ID";
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



        public int IngredientUpdate(string iID, string iName, string sID, string sName, string idescription, 
            int iquantity, decimal icost_Price, decimal isale_Price, int ilevel, string iconcern_Type, string iskin_Type, 
            string isensitivity, string itype)
        {
            string queryStr = "UPDATE Ingredient SET" +
                //" Product_ID = @productID, " +

                " ingredient_Name = @ingredient_Name, " +
                " suppl_ID = @suppl_ID, " +
                " suppl_Name = @suppl_Name, " +
                " description = @description, " +
                " quantity = @quantity, " +
                " cost_Price = @cost_Price, " +
                " sale_Price = @sale_Price, " +
                " level = @level, " +     
                " concern_Type = @concern_Type, " +
                " skin_Type = @skin_Type, " +
                " sensitivity = @sensitivity, " +
                " type = @type " +
                " WHERE ingredient_ID = @ingredient_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);


            cmd.Parameters.AddWithValue("@ingredient_ID", iID);
            cmd.Parameters.AddWithValue("@ingredient_Name", iName);
            cmd.Parameters.AddWithValue("@suppl_ID", sID);
            cmd.Parameters.AddWithValue("@suppl_Name", sName);
            cmd.Parameters.AddWithValue("@description", idescription);
            cmd.Parameters.AddWithValue("@quantity", iquantity);
            cmd.Parameters.AddWithValue("@cost_Price", icost_Price);
            cmd.Parameters.AddWithValue("@sale_Price", isale_Price);
            cmd.Parameters.AddWithValue("@level", ilevel);         
            cmd.Parameters.AddWithValue("@concern_Type", iconcern_Type);
            cmd.Parameters.AddWithValue("@skin_Type", iskin_Type);
            cmd.Parameters.AddWithValue("@sensitivity", isensitivity);
            cmd.Parameters.AddWithValue("@type", itype);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }//end Update

    }
}