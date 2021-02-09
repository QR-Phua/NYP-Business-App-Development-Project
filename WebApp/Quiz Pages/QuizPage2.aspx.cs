using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Quiz_Pages
{
    public partial class QuizPage2 : System.Web.UI.Page
    {
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

            if (Session["concerns"] != null )
            {

                string[] concernsMem = Session["concerns"].ToString().Split(',');

                foreach (ListItem li in cb_Concerns.Items)
                {
                   for (int i=0; i < concernsMem.Length; i++)
                   {
                        if(concernsMem[i] == li.Value)
                        {
                            li.Selected = true;
                        }
                   }
                }

            }

            Session["concerns"] = null;
            
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // Check if only 2 skin concerns chosen.

            var items = from ListItem li in cb_Concerns.Items
                        where li.Selected == true
                        select li;

            string concerns = "";

            if (items.Count() == 2)
            {

                foreach (ListItem li in items)
                {
                    concerns = concerns + li.Value;
                }

                Session["concerns"] = concerns;
                Response.Redirect("QuizPage3.aspx");

            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage1.aspx");            
        }

        protected void cb_Concerns_SelectedIndexChanged(object sender, EventArgs e)

        {
            // linq query to find selected items from checkboxlist
            var items = from ListItem li in cb_Concerns.Items
                        where li.Selected == true
                        select li;

            // Clears away selection if more than 2
            //Helps make submit button work 
            if (items.Count() > 2)
            {

                lbl_Warning.Text = "Only 2 options can be chosen";
                foreach (ListItem li in items)
                {
                    li.Selected = false;  
                }
                lbl_Warning.Attributes.CssStyle.Add("color", "red");

            }

            else if (items.Count() < 2)
            {
                lbl_Warning.Text = "Please select 1 more option";
                foreach (ListItem li in items)
                {
                    li.Selected = false;
                }
                lbl_Warning.Attributes.CssStyle.Add("color", "red");
            }

            
            

        }
    }
}