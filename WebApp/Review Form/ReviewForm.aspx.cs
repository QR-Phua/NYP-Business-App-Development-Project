using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Review_Form
{
    public partial class ReviewForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Retrieve Order details


            // Add in Problem areas from Order details

            string concern_Type1 = "";
            string concern_Type2 = "";
 
            /* Result[2] and Result[3] shall be derived from the Result_ID from Order Detailw
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
            */

            lbl_Problem1.Text = "";
            lbl_Problem2.Text = "";

            //Method of retrieving formulation ID from ORDER DETAILS
            //formulationID to be retrieved from 
            string formulationID = "";


            Formulation formulation = new Formulation(formulationID);

            formulation.retrieveIngredients();

            lbl_Ingredient1.Text = formulation.ingredient1;
            lbl_Ingredient2.Text = formulation.ingredient2;
            lbl_Ingredient3.Text = formulation.ingredient3;



        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int orderID;
            int rating;
            string formulationID;

         
            rating = int.Parse(Slider1.Text);

            // Method for getting orderID AND formulationID from Session.
                


            Debug.WriteLine("WRTING RATING");
            Debug.WriteLine(rating);

            bool outcome;
            /*
            Review review = new Review(formulationID, orderID, rating);
            outcome = review.ReviewInsert(); 
            if (outcome)
            {
                //Redirect back to orders portal
                Response.Redirect("SOMEWEHERE");
                
            }
            */
        }
    }
}