using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Quiz_Pages
{
    public partial class QuizPage5a : System.Web.UI.Page
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

            if (Session["waterCon"] == null)
            {
                Response.Redirect("QuizPage4.aspx");
            }

            if (Session["allerIngredients"] != null)
            {
                string choice = Session["allerIngredients"].ToString();
                
                if (choice == "No")
                {
                    ListItem found = rbl_Allergic.Items.FindByValue("No");
                    found.Selected = true;
                }
                else if (choice == "Yes")
                {
                    ListItem found = rbl_Allergic.Items.FindByValue("Yes");
                    found.Selected = true;
                }
            }

            Session["allerIngredients"] = null;

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage4.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string allergic = null;
            if (rbl_Allergic.SelectedIndex > -1)
            {
                allergic = rbl_Allergic.SelectedItem.Value;
                bool redirect = true;
                if (allergic == "No")
                {
                    string allerIngredients = "No";
                    Session["allerIngredients"] = allerIngredients;
                    redirect = false;
                    
                }
                else
                {
                    string allerIngredients = "Yes";
                    Session["allerIngredients"] = allerIngredients;
                    
                }

                // Generate QuizResult
                string result = "";

                if (Session["skinType"] != null)
                {
                    result += Session["skinType"].ToString();
                }

                if (Session["sensitivity"] != null)
                {
                    result += Session["sensitivity"].ToString();
                }

                if (Session["concerns"] != null)
                {
                    result += Session["concerns"].ToString();
                }

                if (Session["makeup"] != null)
                {
                    result += Session["makeup"].ToString();
                }

                if (Session["waterCon"] != null)
                {
                    result += Session["waterCon"].ToString();
                }

                if (Request.Cookies["QuizResult"] != null)
                {
                    HttpCookie cookie = Request.Cookies["QuizResult"];
                    cookie["result"] = result;
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("QuizResult");
                    cookie["result"] = result;
                    Response.Cookies.Add(cookie);
                }

                if (redirect)
                {
                    Response.Redirect("QuizPage5b.aspx");
                }
                else
                {
                    Response.Redirect("IngredientSelection.aspx");
                }

            }
            else
            {
                lbl_Warning.Text = "Please select an option";
                lbl_Warning.Attributes.CssStyle.Add("color", "red");
            }
        }

        
    }
}