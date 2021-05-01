using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                List<string> list = (List<string>)Session["allerIngredients"];

                
                
                foreach (ListItem li in cb_AllerIngredients.Items)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == li.Value)
                        {
                            li.Selected = true;
                            list[i] = "";
                        }
                        
                    }
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
            
            var items = from ListItem li in cb_AllerIngredients.Items
                        where li.Selected == true
                        select li;

            List<String> list = new List<string>();

            foreach (ListItem li in items)
            {
                list.Add(li.ToString());
            }

            if (list.Count > 0)
            {
                Session["allerIngredients"] = list;
            }
            else
            {
                Session["allerIngredients"] = "No";
            }

            Debug.WriteLine("List Items below!");

            list.ForEach(delegate (String name)
            {
                Debug.WriteLine(name);
            });

            

            Response.Redirect("IngredientSelection.aspx");
            

        }
    }
}