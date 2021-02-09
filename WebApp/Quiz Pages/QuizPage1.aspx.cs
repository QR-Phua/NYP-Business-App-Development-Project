using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class QuizPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["skinType"] != null && Session["sensitivity"] != null)
            {
                
                foreach(ListItem li in rbl_SkinType.Items)
                {
                    if (li.Value.ToString() == Session["skinType"].ToString())
                    {
                        li.Selected = true;
                    }
                }

                
                foreach (ListItem li in rbl_Sensitivity.Items)
                {
                    if (li.Value.ToString() == Session["sensitivity"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

            Session["skinType"] = null;
            Session["sensitivity"] = null;
        }

        
    

        protected void btn_Submit_Click(object sender, EventArgs e)
            {
                Session["skinType"] = null;
                string skinType = null;
                if (rbl_SkinType.SelectedIndex > -1)
                {
                    skinType = rbl_SkinType.SelectedItem.Value;
                    Session["skinType"] = skinType;
                }


                Session["sensitivity"] = null;
                string sensitivity = null;
                if (rbl_Sensitivity.SelectedIndex > -1)
                {
                    sensitivity = rbl_Sensitivity.SelectedItem.Value;
                    Session["sensitivity"] = sensitivity;
                }

                if (skinType != null && sensitivity != null)
                {
                  Response.Redirect("QuizPage2.aspx");
                }
            }

        }
}