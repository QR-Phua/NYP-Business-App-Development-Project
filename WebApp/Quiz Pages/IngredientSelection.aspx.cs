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
            else {
                
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

            string allerIngredients = "";
            if (cookie["allerIngredients"] != null || cookie["allerIngredients"] != "")
            {
                allerIngredients = cookie["allerIngredients"];
            }

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
            else if (result[0] == char.Parse("O")) {
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
            

            TableData = cart.IngredientListRetrieve(skinType,sensitivity,concern_Type1,concern_Type2,level,type);

        }

        [WebMethod(EnableSession = true)]
        public static void getData(string[] ingredients)
        {
            /*
            if (ingredient != null)
            {
                if (ingredients.Count == 0)
                {
                    ingredients.Add(ingredient);
                }
                else
                {
                    bool delete = false;
                    int index = 0;
                    for (int i=0; i<ingredients.Count(); i++)
                    {
                        if (ingredients[i].ToString() == ingredient)
                        {
                            delete = true;
                            index = i;
                        }
                    }

                    if (delete)
                    {
                        ingredients.RemoveAt(index);
                    }
                    else
                    {
                        ingredients.Add(ingredient);
                    }
                }
            } */
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
            // Response.Redirect("~/Shopping Cart/ProductFormulation.aspx");
            /*
            bool result = true;
            
            if (HttpContext.Current.Session["ChosenIngredient1"] == null || HttpContext.Current.Session["ChosenIngredient1"].ToString() == "")
            {
                result = false;
                Debug.WriteLine("ChosenIngredient1 is empty!");
            }
            if (HttpContext.Current.Session["ChosenIngredient2"] == null || HttpContext.Current.Session["ChosenIngredient2"].ToString() == "")
            {
                result = false;
                Debug.WriteLine("ChosenIngredient2 is empty!");
            }
            if (HttpContext.Current.Session["ChosenIngredient3"] == null || HttpContext.Current.Session["ChosenIngredient3"].ToString() == "")
            {
                result = false;
                Debug.WriteLine("ChosenIngredient3 is empty!");
            }

            if (result)
            {
                
                ShoppingCart cart = (ShoppingCart)Session["CartObject"];


                cart.ingredient1 = HttpContext.Current.Session["ChosenIngredient1"].ToString();
                cart.ingredient2 = HttpContext.Current.Session["ChosenIngredient2"].ToString();
                cart.ingredient3 = HttpContext.Current.Session["ChosenIngredient3"].ToString();

                HttpCookie cookie = new HttpCookie("cartInfo");
                cookie["UnsignedCartID"] = cart.cart_ID;
                cookie["Ingredient1"] = HttpContext.Current.Session["ChosenIngredient1"].ToString();
                cookie["Ingredient2"] = HttpContext.Current.Session["ChosenIngredient2"].ToString();
                cookie["Ingredient3"] = HttpContext.Current.Session["ChosenIngredient3"].ToString();

                Response.Cookies.Add(cookie);
                Session["CartObject"] = cart;
                if (Session["CartObject"] != null)
                {
                    Label12.Text = "exists";
                }
                else
                {
                    Label12.Text = "Nothing!";
                }

                if (HttpContext.Current.Session["ChosenIngredient1"] != null)
                {
                    Label9.Text = HttpContext.Current.Session["ChosenIngredient1"].ToString();
                }
                else
                {
                    Label9.Text = "Chosen1 is empty!";
                }

                if (HttpContext.Current.Session["ChosenIngredient2"] != null)
                {
                    Label10.Text = HttpContext.Current.Session["ChosenIngredient2"].ToString();
                }
                else
                {
                    Label10.Text = "Chosen2 is empty!";
                }

                if (HttpContext.Current.Session["ChosenIngredient3"] != null)
                {
                    Label11.Text = HttpContext.Current.Session["ChosenIngredient3"].ToString();
                }
                else
                {
                    Label11.Text = "Chosen1 is empty!";
                }

                if (result)
                {
                    Response.Redirect("~/Shopping Cart/ProductFormulation.aspx");
                }
            }
            */
        }
    }
}