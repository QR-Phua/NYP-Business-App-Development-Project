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

            string concern_Type1 = "R";
            string concern_Type2 = "Y";

            string[] result = {"A", "B", "R", "Y"};

           
            if (char.Parse(result[2]) == char.Parse("A"))
            {
                concern_Type1 = "Acne";
            }
            else if (char.Parse(result[2]) == char.Parse("R"))
            {
                concern_Type1 = "Redness and Irritation";
            }
            else if (char.Parse(result[2]) == char.Parse("D"))
            {
                concern_Type1 = "Dullness and Age Spots";
            }
            else if (char.Parse(result[2]) == char.Parse("B"))
            {
                concern_Type1 = "Blemishes and Pigmentation";
            }
            else if (char.Parse(result[2]) == char.Parse("Y"))
            {
                concern_Type1 = "Dryness";
            }
            else
            {
                concern_Type1 = "Blackheads and Whiteheads";
            }

            //determine concern 2
            if (char.Parse(result[3]) == char.Parse("A"))
            {
                concern_Type2 = "Acne";
            }
            else if (char.Parse(result[3]) == char.Parse("R"))
            {
                concern_Type2 = "Redness and Irritation";
            }
            else if (char.Parse(result[3]) == char.Parse("D"))
            {
                concern_Type2 = "Dullness and Age Spots";
            }
            else if (char.Parse(result[3]) == char.Parse("B"))
            {
                concern_Type2 = "Blemishes and Pigmentation";
            }
            else if (char.Parse(result[3]) == char.Parse("Y"))
            {
                concern_Type2 = "Dryness";
            }
            else
            {
                concern_Type2 = "Blackheads and Whiteheads";
            }
            

            lbl_Problem1.Text = concern_Type1;
            lbl_Problem2.Text = concern_Type2;

            //Method of retrieving formulation ID from ORDER DETAILS
            //formulationID to be retrieved from 

            string formulationID = "A1";


            Formulation formulation = new Formulation(formulationID);

            formulation.retrieveIngredients();

            lbl_Ingredient1.Text = formulation.ingredient1;
            lbl_Ingredient2.Text = formulation.ingredient2;
            lbl_Ingredient3.Text = formulation.ingredient3;



        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //CHange this to derive from session
            int orderID = 5;
            int rating;

            //Change this to derive from Session
            string formulationID = "A1";

         
            rating = int.Parse(Slider1.Text);

            // Method for getting orderID AND formulationID from Session.
                


            Debug.WriteLine("WRTING RATING");
            Debug.WriteLine(rating);

            bool outcome;
            
            Review review = new Review(formulationID, orderID, rating);
            outcome = review.ReviewInsert(); 
            if (outcome)
            {
                //Redirect back to orders portal!!
                Response.Redirect("~/Home.aspx");
                
            }
            
        }
    }
}