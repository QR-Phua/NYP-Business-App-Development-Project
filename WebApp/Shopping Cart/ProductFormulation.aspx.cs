using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Shopping_Cart
{
    public partial class ProductFormulation : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CartObject"] == null)
            {
                Response.Redirect("~/Quiz Pages/IngredientSelection.aspx");
            }


            if (Request.Cookies["QuizResult"] == null)
            {
                Response.Redirect("~/Quiz Pages/QuizPage1.aspx");
            }

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            if (!IsPostBack)
            {
                if (cart.cleanserQuantity > 0)
                {
                    ddl_Cleanser.SelectedValue = cart.cleanserQuantity.ToString();
                    lbl_Cleanser.Text = "Quantity Selected: " + cart.cleanserQuantity.ToString();
                }
                if (cart.tonerQuantity > 0)
                {
                    ddl_Toner.SelectedValue = cart.tonerQuantity.ToString();
                    lbl_Toner.Text = "Quantity Selected: " + cart.tonerQuantity.ToString();
                }
                if (cart.moisturiserQuantity > 0)
                {
                    ddl_Moisturiser.SelectedValue = cart.moisturiserQuantity.ToString();
                    lbl_Moisturiser.Text = "Quantity Selected: " + cart.moisturiserQuantity.ToString();
                }
                if (cart.frequency > -1)
                {
                    ddl_Subscription.SelectedValue = cart.frequency.ToString();
                    if (cart.frequency == 0)
                    {
                        lbl_Subscription.Text = "No Subscription";
                    }
                    else if (cart.frequency == 1)
                    {
                        lbl_Subscription.Text = "Subscription for monthly delivery";
                    }
                    else
                    {
                        lbl_Subscription.Text = "Subscription for quarterly (3 Month) delivery";
                    }
                }
            }
            else
            {

            }
            
           
            HttpCookie cookie = Request.Cookies["cartInfo"];
            if (cookie == null)
            {
                cookie = new HttpCookie("cartInfo");
            }
            Response.Cookies.Add(cookie);
            /*
            lbl_Ingredient1.Text = cookie["Ingredient1"];

            lbl_Ingredient2.Text = cookie["Ingredient2"];

            lbl_Ingredient3.Text = cookie["Ingredient3"];
            */

            HttpCookie quizCookie = Request.Cookies["QuizResult"];
            lbl_Concern1.Text = quizCookie["concernType1"];
            lbl_Concern2.Text = quizCookie["concernType2"];

            string cartID = cart.cart_ID;

            TempIngredients temp = new TempIngredients();

            DataTable dt = temp.ingredientRetrieve(cartID);
            foreach (DataRow row in dt.Rows)
            {
                lbl_Ingredient1.Text = row["ingredient1"].ToString();
                lbl_Ingredient2.Text = row["ingredient2"].ToString();
                lbl_Ingredient3.Text = row["ingredient3"].ToString();
            }
        }

        protected void btn_Reselect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Quiz Pages/IngredientSelection.aspx");
        }

        protected void btn_AddCleanser_Click(object sender, EventArgs e)
        {
            if (ddl_Cleanser.SelectedIndex > 0)
            {
                Session.Remove("CleanserQuantity");
                Session["CleanserQuantity"] = ddl_Cleanser.SelectedValue;
                lbl_Cleanser.Text = "Quantity Selected: " + Session["CleanserQuantity"].ToString();
                lbl_Cleanser.Attributes.CssStyle.Add("color", "black");
            }
            else
            {
                lbl_Cleanser.Text = "Invalid Quantity selected";
                lbl_Cleanser.Attributes.CssStyle.Add("color", "red");
            }
        }

        protected void btn_AddToner_Click(object sender, EventArgs e)
        {
            if (ddl_Toner.SelectedIndex > 0)
            {
                Session.Remove("TonerQuantity");
                Session["TonerQuantity"] = ddl_Toner.SelectedValue;
                lbl_Toner.Text = "Quantity Selected: " + Session["TonerQuantity"].ToString();
                lbl_Toner.Attributes.CssStyle.Add("color", "black");
            }
            else
            {
                lbl_Toner.Text = "Invalid Quantity selected";
                lbl_Toner.Attributes.CssStyle.Add("color", "red");
            }
        }

        protected void btn_AddMoisturiser_Click(object sender, EventArgs e)
        {
            if (ddl_Moisturiser.SelectedIndex > 0)
            {
                Session.Remove("MoisturiserQuantity");
                Session["MoisturiserQuantity"] = ddl_Moisturiser.SelectedValue;
                lbl_Moisturiser.Text = "Quantity Selected: " + Session["MoisturiserQuantity"].ToString();
                lbl_Moisturiser.Attributes.CssStyle.Add("color", "black");
            }
            else
            {
                lbl_Moisturiser.Text = "Invalid Quantity selected";
                lbl_Moisturiser.Attributes.CssStyle.Add("color", "red");
            }
        }

        protected void ddl_Subscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Subscription.SelectedIndex > -1)
            {

                if (int.Parse(ddl_Subscription.SelectedValue.ToString()) == 0)
                {
                    Session.Remove("OrderSubscription");
                    Session["OrderSubscription"] = 0;
                    lbl_Subscription.Text = "No Subscription";
                }

                else if (int.Parse(ddl_Subscription.SelectedValue.ToString()) == 1)
                {
                    Session.Remove("OrderSubscription");
                    Session["OrderSubscription"] = 1;
                    lbl_Subscription.Text = "Subscription for monthly delivery";
                }


                else if (int.Parse(ddl_Subscription.SelectedValue.ToString()) == 3)
                {
                    Session.Remove("OrderSubscription");
                    Session["OrderSubscription"] = 3;
                    lbl_Subscription.Text = "Subscription for quarterly (3 Month) delivery";
                }
                else
                { }

            }
            else
            {
                lbl_Redirect.Text = "Please select whether you would like to have a subscription!";
            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            bool redirect = false;
            string error = "";
            
            if (Session["OrderSubscription"] == null)
            {
                error = error + "Please select whether you would like to have a subscription!";
                
            }

            if ((int)Session["OrderSubscription"] < 0)
            {
                error = error + "Please select whether you would like to have a subscription!";
            }

            if (Session["CleanserQuantity"] == null && Session["TonerQuantity"] == null && Session["MoisturiserQuantity"] == null)
            {
                error = error + "Please select a product and the quantity you desire!";
                
            }

            if ((Session["CleanserQuantity"] != null || Session["TonerQuantity"] != null || Session["MoisturiserQuantity"] != null) && (Session["OrderSubscription"] != null))
            {
                redirect = true;
            }

            if (!redirect)
            {
                lbl_Redirect.Text = error;
                lbl_Redirect.Attributes.CssStyle.Add("color", "red");

            }
            else
            {
                ShoppingCart cart = (ShoppingCart)Session["CartObject"];
                HttpCookie quizResult = Request.Cookies["QuizResult"];
                string waterCon = quizResult["waterCon"];
                string makeup = quizResult["makeup"];

                if (waterCon == "Bad")
                {
                    cart.tonerBase = "Moisture Base";
                    cart.moisturiserBase = "Cream Base";
                }
                else
                {
                    cart.tonerBase = "Hydro Base";
                    cart.moisturiserBase = "Gel Base";
                }

                if (makeup == "Yes")
                {
                    cart.cleanserBase = "Makeup Base";
                }
                else
                {
                    cart.cleanserBase = "Gentle Base";
                }
                
                if (Session["CleanserQuantity"] != null)
                {
                    cart.cleanserQuantity = int.Parse(Session["CleanserQuantity"].ToString());
                }
                else
                {
                    cart.cleanserQuantity = 0;
                }

                if (Session["TonerQuantity"] != null)
                {
                    cart.tonerQuantity = int.Parse(Session["TonerQuantity"].ToString());
                }
                else
                {
                    cart.tonerQuantity = 0;
                }

                if (Session["MoisturiserQuantity"] != null)
                {
                    cart.moisturiserQuantity = int.Parse(Session["MoisturiserQuantity"].ToString());
                }
                else
                {
                    cart.moisturiserQuantity = 0;
                }

                
                cart.ingredient1 = lbl_Ingredient1.Text;
                cart.ingredient2 = lbl_Ingredient2.Text;
                cart.ingredient3 = lbl_Ingredient3.Text;

                cart.frequency = int.Parse(Session["OrderSubscription"].ToString());

                HttpCookie cookie = Request.Cookies["cartInfo"];
                
                cookie["CleanserQuantity"] = cart.cleanserQuantity.ToString();
                cookie["TonerQuantity"] = cart.tonerQuantity.ToString();
                cookie["MoisturiserQuantity"] = cart.moisturiserQuantity.ToString(); 
                cookie["CleanserBase"] = cart.cleanserBase;
                cookie["TonerBase"] = cart.tonerBase;
                cookie["MoisturiserBase"] = cart.moisturiserBase;
                cookie["Frequency"] = cart.frequency.ToString();
                Response.Cookies.Add(cookie);
                Session["CartObject"] = cart;

                if (Session["Customer"] != null)
                {
                    /*
                    string custID = Session["Customer"]

                    some method of retreival 

                    bool result = cart.SignedCartInsert(custID);
                    if (result)
                    {
                        Response.Redirect("ShoppingCart.aspx");
                    }
                    */
                }
                else
                {
                    bool result = cart.CartInsert();
                    if (result)
                    {
                        Response.Redirect("ShoppingCart.aspx");
                    }
                }
                            

            }
        }

        protected void btn_Retake_Click(object sender, EventArgs e)
        {
            ShoppingCart cart = (ShoppingCart)Session["CartObject"];
            string cartID = cart.cart_ID;

            TempIngredients ingredients = new TempIngredients();
            bool result = ingredients.ingredientDeleteAll(cartID);

            if (result)
            {
                Session.Remove("skinType");

                Session.Remove("sensitivity");

                Session.Remove("concerns");

                Session.Remove("makeup");

                Session.Remove("waterCon");

                Session.Remove("allerIngredients");

                if (cart.cleanserQuantity == 0 && cart.tonerQuantity == 0 && cart.moisturiserQuantity == 0 && cart.frequency == -1)
                {
                    Debug.WriteLine("No Cart Info, deleting ingredients only");
                    Session.Remove("CartObject");
                    HttpContext.Current.Response.Cookies.Remove("QuizResult");
                    Response.Redirect("~/Quiz Pages/QuizPage1.aspx");
                }

                else
                {
                    // Check if login 

                    if (Session["Customer"] == null)
                    {
                        Debug.WriteLine("Deleting Unsigned Cart");
                        bool tran1 = cart.UnsignedDeleteAllCartItem();
                        bool tran2 = cart.UnsignedDeleteCart();
                        if (tran1 && tran2)
                        {
                            Session.Remove("CartObject");
                            HttpContext.Current.Response.Cookies.Remove("QuizResult");
                            HttpContext.Current.Response.Cookies.Remove("cartInfo");
                            Response.Redirect("~/Quiz Pages/QuizPage1.aspx");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Deleting Signed Cart");
                        bool tran1 = cart.SignedDeleteAllCartItem();
                        bool tran2 = cart.SignedDeleteCart();

                        if (tran1 && tran2)
                        {
                            Session.Remove("CartObject");
                            HttpContext.Current.Response.Cookies.Remove("QuizResult");
                            HttpContext.Current.Response.Cookies.Remove("cartInfo");
                            Response.Redirect("~/Quiz Pages/QuizPage1.aspx");
                        }
                    }

                }
            }
        }

            
        
    }
}