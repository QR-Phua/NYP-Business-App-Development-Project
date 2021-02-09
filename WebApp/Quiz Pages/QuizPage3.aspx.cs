using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Quiz_Pages
{
	public partial class QuizPage3 : System.Web.UI.Page
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

            if (Session["concerns"] == null)
            {
                Response.Redirect("QuizPage2.aspx");
            }

            if (Session["makeup"] != null)
            {

                foreach (ListItem li in rbl_Makeup.Items)
                {
                    if (li.Value.ToString() == Session["makeup"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

            Session["makeup"] = null;
            
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage2.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string makeup = null;
            if (rbl_Makeup.SelectedIndex > -1)
            {
                makeup = rbl_Makeup.SelectedItem.Value;
                Session["makeup"] = makeup;

                Response.Redirect("QuizPage4.aspx");
            }
            else
            {
                lbl_Warning.Text = "Please select an option";
                lbl_Warning.Attributes.CssStyle.Add("color", "red");
            }
        }
    }
}