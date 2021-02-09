using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Quiz_Pages
{
    public partial class QuizPage4 : System.Web.UI.Page
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

            if (Session["makeup"] == null)
            {
                Response.Redirect("QuizPage3.aspx");
            }

            if (Session["waterCon"] != null)
            {

                foreach (ListItem li in rbl_WaterCon.Items)
                {
                    if (li.Value.ToString() == Session["waterCon"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

            Session["waterCon"] = null;

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage3.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string waterCon = null;
            if (rbl_WaterCon.SelectedIndex > -1)
            {
                waterCon = rbl_WaterCon.SelectedItem.Value;
                Session["waterCon"] = waterCon;

                Response.Redirect("QuizPage5a.aspx");
            }
            else
            {
                lbl_Warning.Text = "Please select an option";
                lbl_Warning.Attributes.CssStyle.Add("color", "red");
            }
        }
    }
}