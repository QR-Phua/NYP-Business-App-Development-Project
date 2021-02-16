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

            HttpCookie quizResult = Request.Cookies["QuizResult"];
            string waterCon = quizResult["waterCon"];
            string makeup = quizResult["makeup"];

            if (waterCon == "Bad")
            {
                lbl_TonerBase.Text = "Moisture Base";
                lbl_MoisturiserBase.Text = "Cream Base";
            }
            else
            {
                lbl_TonerBase.Text = "Hydro Base";
                lbl_MoisturiserBase.Text = "Gel Base";
            }

            if (makeup == "Yes")
            {
                lbl_CleanserBase.Text = "Makeup Base";
            }
            else
            {
                lbl_CleanserBase.Text = "Gentle Base";
            }

            HttpCookie cookie = Request.Cookies["cartInfo"];
            if (cookie == null)
            {
                cookie = new HttpCookie("cartInfo");
            }
            Response.Cookies.Add(cookie);
            
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

            Formulation formulation = new Formulation(lbl_Ingredient1.Text, lbl_Ingredient2.Text, lbl_Ingredient3.Text);

            // check if ingredients selected alr exists as a formulation and storing the formulation ID
            string formulationExistResult = formulation.retrieveFormulationID();
            
            // if retrieved id has nothing then it does not exist
            bool formulationSelectedExist = false;
            if (formulationExistResult != "")
            {
                formulationSelectedExist = true;
            }

            string imptResult = quizCookie["imptResult"].ToString();
            Debug.WriteLine(imptResult);

            // retrieve formulations that have been bought and reviewed from DB
            DataTable ranking = formulation.retrieveRecommendations(imptResult);


            if (ranking.Rows.Count > 0)
            {
                Debug.WriteLine("ranking datatable exists and has rows");
                int selectedPerc = 0; // set selected formulation percent to 0 first 
                

                if (formulationSelectedExist)
                {
                    // getting selected ingredients rating percentage since it exists in DB
                    DataRow[] selectedFormRows = ranking.Select(string.Format("FormulationID = '{0}'", formulationExistResult));
                    if (selectedFormRows.Length > 0)
                    {
                        for (int i = 0; i < selectedFormRows.Length; i++)
                        {
                            Debug.WriteLine(selectedFormRows[i]["Percentage"]);

                            //Set selectedPerc with rating of formulation
                            selectedPerc = (int)selectedFormRows[i]["Percentage"];
                        }
                    }
                }

                // getting the first row perc since is the highest rating percentage
                DataRow firstRow = ranking.Rows[0];
                string firstFormID = firstRow["FormulationID"].ToString();
                int firstPerc = (int)firstRow["Percentage"];

                //show recommendations if ranking more than or equal to 50% satisfaction
                if (firstPerc >= 50)
                {
                    //retrieve and store ingredients into a list for the highest rated formulation
                    List<string> list = formulation.recommendationIngredientsRetrieve(firstRow["FormulationID"].ToString());

                    //store to session for future retrieval when button is click
                    Session["RecommendedIngredients"] = list;

                    if (selectedPerc > 0) // if selected > 0 to compare accurately
                    {

                        // if highest rating more than selected rating
                        if (firstPerc > selectedPerc)
                        {
                            // displays text
                            lbl_Recommended.Text = String.Format("We have found other combination of Ingredients that may work better to " +
                                "target your selected Skin Concerns. You may want to try this highest rated combination for your results. " +
                                "The satisfaction rate is {0}% among customers with the same Skin Quiz Result as you and its ingredients are {1}, {2} and {3}." +
                                " If you wish to try it out, click the button below.", firstPerc, list[0], list[1], list[2]);

                            //enables button to change the ingredients
                            btn_TakeRecommended.Visible = true;

                        }

                        // if ratings are equal
                        else if (firstPerc == selectedPerc)
                        {

                            lbl_Recommended.Text = String.Format("Your chosen combination of ingredients is one of the highest rated combination based on your Skin Quiz Result! " +
                                "The satisfaction rate among customers is {0}%. You're all good!", firstPerc);

                            //hides button since recommendation is the same
                            btn_TakeRecommended.Visible = false;

                        }

                        else if (firstPerc < selectedPerc)
                        {
                            lbl_Recommended.Text = String.Format("Your chosen combination of ingredients is the highest rated combination based on your Skin Quiz Result! " +
                                "The satisfaction rate among customers is {0}%. You're all good!", selectedPerc);

                            //hides button since recommendation is the same
                            btn_TakeRecommended.Visible = false;
                        }
                    }

                    else // since no rating found, recommend highest
                    {
                        // displays text
                        lbl_Recommended.Text = String.Format("We have found other combination of Ingredients that may work better to " +
                            "target your selected Skin Concerns. You may want to try this highest rated combination for your results. " +
                            "The satisfaction rate is {0}% among customers with the same Skin Quiz Result as you and its ingredients are {1}, {2} and {3}." +
                            " If you wish to try it out, click the button below.", firstPerc, list[0], list[1], list[2]);

                        //enables button to change the ingredients
                        btn_TakeRecommended.Visible = true;
                    }

                }
                else
                {
                    lbl_Recommended.Text = String.Format("We can't give much recommendation at this point in time. This can be due to many factors " +
                        "such as a lack of reviews on the ingredient combinations for this particular Skin Quiz Result. We recommend choosing " +
                        "the combination of ingredients that you like in the previous step and to go and try it out! Remember that everyone's Skin is different!");

                    //hides button since no recommendation
                    btn_TakeRecommended.Visible = false;
                }

            }
            else
            {
                Debug.WriteLine("ranking datatable DOES NOT HAVE ROWS");
                lbl_Recommended.Text = String.Format("We can't give much recommendation at this point in time. This can be due to many factors " +
                        "such as a lack of reviews on the ingredient combinations bought for this particular Skin Quiz Result and etc. We recommend choosing " +
                        "the combination of ingredients that you like in the previous step and proceed to try it out!");

                //hides button since no recommendation
                btn_TakeRecommended.Visible = false;
            }
        

        }

        protected void btn_TakeRecommended_Click(object sender, EventArgs e)
        {
            List<string> list = (List<string>)Session["RecommendedIngredients"];

            string ingredient1, ingredient2, ingredient3;

            ingredient1 = list[0];
            ingredient2 = list[1];
            ingredient3 = list[2];

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            TempIngredients temp = new TempIngredients(cart.cart_ID, ingredient1, ingredient2, ingredient3);

            bool result = temp.ingredientInsert();

            if (result)
            {
                Response.Redirect("~/Shopping Cart/ProductFormulation.aspx");
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
                if (Session["CleanserQuantity"] != null)
                {
                    Session.Remove("CleanserQuantity");
                }
                
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
                if (Session["TonerQuantity"] != null)
                {
                    Session.Remove("TonerQuantity");
                }

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
                if (Session["MoisturiserQuantity"] != null)
                {
                    Session.Remove("MoisturiserQuantity");
                }
                
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
                lbl_Redirect.Text = error;
            }
            else
            {
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

                        some method of retrieval 

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