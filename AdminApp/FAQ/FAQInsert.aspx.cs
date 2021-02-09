using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class FAQInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;

            FAQ Faq = new FAQ(tb_faq_ID.Text, tb_faq_Title.Text, tb_faq_Question.Text, tb_faq_Answer.Text);


            result = Faq.FAQInsert();

            if (result > 0)
            {

                Response.Write("<script>alert('Insert successful');</script>");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }

        }


        protected void btn_FaqView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FAQView.aspx");
        }
    }
}