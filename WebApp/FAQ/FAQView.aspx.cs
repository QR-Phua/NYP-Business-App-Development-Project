using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class FAQView : System.Web.UI.Page
    {
        FAQ aFaq = new FAQ();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bind();
            }

        }
        protected void bind()
        {
            List<FAQ> faqList = new List<FAQ>();
            faqList = aFaq.getfaqall();
            gvFAQ.DataSource = faqList;
            gvFAQ.DataBind();
        }
    }
}