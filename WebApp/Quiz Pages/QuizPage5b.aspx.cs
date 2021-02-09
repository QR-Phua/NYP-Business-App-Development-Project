using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebApp.Quiz_Pages
{
    public partial class QuizPage5b : System.Web.UI.Page
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

            if (Session["allerIngredients"] == null)
            {
                Response.Redirect("QuizPage5a.aspx");
            }

            if (Session["allerIngredients"].ToString() == "No")
            {
                Response.Redirect("IngredientSelection.aspx");
            }
                      

            if (Session["allerIngredients"].ToString() != "Yes")
            {

                string[] ingredientsMem = Session["allerIngredients"].ToString().Split(',');

                tb_Others.Text = "";
                
                foreach (ListItem li in cb_AllerIngredients.Items)
                {
                    for (int i = 0; i < ingredientsMem.Length; i++)
                    {
                        if (ingredientsMem[i] == li.Value)
                        {
                            li.Selected = true;
                            ingredientsMem[i] = "";
                        }
                        
                    }
                }

                for (int i = 0; i < ingredientsMem.Length; i++)
                {
                    if (ingredientsMem[i] != "")
                    {
                        tb_Others.Text = tb_Others.Text + ingredientsMem[i] + ",";
                    }                    
                }

                if (tb_Others.Text != "")
                {
                    lbl_Load.Visible = true;
                }

                Session["allerIngredients"] = "Yes";
            }
                     
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizPage5a.aspx");
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
            string allerIngredients = null;

            var items = from ListItem li in cb_AllerIngredients.Items
                        where li.Selected == true
                        select li;


            foreach (ListItem li in items)
            {
                allerIngredients = allerIngredients + li.Value + ",";
            }

            if (tb_Others != null)
            {
                allerIngredients = allerIngredients + tb_Others.Text + ",";
                allerIngredients = allerIngredients.Trim();
            }

            Session["allerIngredients"] = allerIngredients;

            HttpCookie cookie = Request.Cookies["QuizResult"];
            cookie["allerIngredients"] = allerIngredients;
            Response.Cookies.Add(cookie);

            Response.Redirect("IngredientSelection.aspx");
            

        }
    }
}