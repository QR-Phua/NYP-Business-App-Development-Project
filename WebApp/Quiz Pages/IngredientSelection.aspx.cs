using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace WebApp
{
    public partial class IngredientSelection : System.Web.UI.Page
    {
        public DataTable TableData = new DataTable();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["skinType"] == null)
            {
                Response.Redirect("QuizPage1.aspx");
            }

            if (Session["sensitivity"] == null)
            {
                Response.Redirect("QuizPage1.aspx");
            }

            if (Session["concerns"] == null)
            {
                Response.Redirect("QuizPage2.aspx");
            }

            if (Session["makeup"] == null)
            {
                Response.Redirect("QuizPage3.aspx");
            }

            if (Session["waterCon"] == null)
            {
                Response.Redirect("QuizPage4.aspx");
            }

            if (Session["allerIngredients"] == null)
            {
                Response.Redirect("QuizPage5a.aspx");
            }


            if (Request.Cookies["QuizResult"] == null)
            {
                Response.Redirect("QuizPage1.aspx");

            }
            else
            {

                HttpCookie cookie = Request.Cookies["QuizResult"];
                if (cookie["result"] == null || cookie["result"] == "")
                {
                    Response.Redirect("QuizPage1.aspx");
                }
            }


            if (Session["CartObject"] == null)
            {
                ShoppingCart cart = new ShoppingCart();
                Session["CartObject"] = cart;
            }


            if (!IsPostBack)
            {
                GetAllData();
            }



        }

        protected void GetAllData()
        {

            HttpCookie cookie = Request.Cookies["QuizResult"];
            string result = cookie["result"];

            string skinType, sensitivity, concern_Type1, concern_Type2, makeup, waterCon, type;
            int level = 1;

            type = "Option";
            //determine skinType
            if (result[0] == char.Parse("D"))
            {
                skinType = "Dry";
            }
            else if (result[0] == char.Parse("B"))
            {
                skinType = "Balanced";
            }
            else if (result[0] == char.Parse("O"))
            {
                skinType = "Oily";
            }
            else
            {
                skinType = "Combination";
            }
            //determine sensitivity
            if (result[1] == char.Parse("N"))
            {
                sensitivity = "No";
                level = 5;
            }
            else
            {
                sensitivity = "Yes";
                level = 3;
            }
            //determine concern 1
            if (result[2] == char.Parse("A"))
            {
                concern_Type1 = "Acne";
            }
            else if (result[2] == char.Parse("R"))
            {
                concern_Type1 = "Redness and Irritation";
            }
            else if (result[2] == char.Parse("D"))
            {
                concern_Type1 = "Dullness and Age Spots";
            }
            else if (result[2] == char.Parse("B"))
            {
                concern_Type1 = "Blemishes and Pigmentation";
            }
            else if (result[2] == char.Parse("Y"))
            {
                concern_Type1 = "Dryness";
            }
            else
            {
                concern_Type1 = "Blackheads and Whiteheads";
            }
            //determine concern 2
            if (result[3] == char.Parse("A"))
            {
                concern_Type2 = "Acne";
            }
            else if (result[3] == char.Parse("R"))
            {
                concern_Type2 = "Redness and Irritation";
            }
            else if (result[3] == char.Parse("D"))
            {
                concern_Type2 = "Dullness and Age Spots";
            }
            else if (result[3] == char.Parse("B"))
            {
                concern_Type2 = "Blemishes and Pigmentation";
            }
            else if (result[3] == char.Parse("Y"))
            {
                concern_Type2 = "Dryness";
            }
            else
            {
                concern_Type2 = "Blackheads and Whiteheads";
            }
            //determine makeup
            if (result[4] == char.Parse("Y"))
            {
                makeup = "Yes";
            }
            else
            {
                makeup = "No";
            }
            //determine waterCon
            if (result[5] == char.Parse("S") || result[5] == char.Parse("M"))
            {
                waterCon = "Bad";
            }
            else { waterCon = "Good"; }

            cookie["concernType1"] = concern_Type1;
            cookie["concernType2"] = concern_Type2;
            cookie["waterCon"] = waterCon;
            cookie["makeup"] = makeup;
            Response.Cookies.Add(cookie);


            ShoppingCart cart = (ShoppingCart)Session["CartObject"];


            if (cart == null)
            {
                cart = new ShoppingCart();
            }


            TableData = cart.IngredientListRetrieve(skinType, sensitivity, concern_Type1, concern_Type2, level, type);

            bool allerIngredients = false;
            if (Session["allerIngredients"].ToString() != "No")
            {
                allerIngredients = true;
            }

            if (allerIngredients)
            {
                List<string> list = (List<string>)Session["allerIngredients"];

                TableData.AcceptChanges();
                foreach (DataRow row in TableData.Rows)
                {
                    foreach (string item in list)
                    {
                        if (row["Ingredient_Name"].ToString() == item)
                        {
                            row.Delete();
                        }

                    }

                }
                TableData.AcceptChanges();
            }


            
            if (Session["allerIngredients"].ToString() != "No")
            {
                allerIngredients = true;
            }
            
            if (allerIngredients)
            {
                List<string> list = (List<string>)Session["allerIngredients"];

                TableData.AcceptChanges();
                foreach (DataRow row in TableData.Rows)
                {
                    foreach (string item in list)
                    {
                        if (row["Ingredient_Name"].ToString() == item)
                        {
                            row.Delete();
                        }

                    }
                    
                }
                TableData.AcceptChanges();
            }
            

        }

        [WebMethod(EnableSession = true)]
        public static void getData(string[] ingredients)
        {

            if (ingredients != null)
            {
                Debug.WriteLine(ingredients);
                Debug.WriteLine("In AJAX WebMethod");
                string ingredient1, ingredient2, ingredient3;
                ingredient1 = ingredients[0].Trim();
                ingredient2 = ingredients[1].Trim();
                ingredient3 = ingredients[2].Trim();

                ShoppingCart cart = (ShoppingCart)HttpContext.Current.Session["CartObject"];

                TempIngredients temp = new TempIngredients(cart.cart_ID, ingredient1, ingredient2, ingredient3);
                bool result = temp.ingredientInsert();
            }
            else
            {
                Debug.WriteLine("FAILED!!!");
            }

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage5a.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}