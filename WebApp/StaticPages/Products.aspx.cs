using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.StaticPages
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_TakeQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Quiz Pages/QuizPage1.aspx");
        }
    }
}