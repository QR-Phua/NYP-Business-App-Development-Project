using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
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

        protected void gvFAQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvFAQ.SelectedRow;

            // Get Ingredient ID from the selected row, which is the 
            // first row, i.e. index 0.
            string faq_ID = row.Cells[0].Text;

            // Redirect to next page, with the Ingredient Id added to the URL,
            // e.g. IngredienttDetails.aspx?FaqID=1
            Response.Redirect("FAQDetails.aspx?faq_ID=" + faq_ID);
        }

        protected void btn_AddFaq_Click(object sender, EventArgs e)
        {
            Response.Redirect("FAQInsert.aspx");
        }

        protected void gvFAQ_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            FAQ Faq = new FAQ();
            string categoryID = gvFAQ.DataKeys[e.RowIndex].Value.ToString();
            result = Faq.FAQDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('FAQ remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('FAQ removal NOT successfully');</script>");
            }

            Response.Redirect("FAQView.aspx");
        }

        protected void gvFAQ_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFAQ.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvFAQ_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFAQ.EditIndex = -1;
            bind();
        }

        protected void gvFAQ_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            FAQ Faq = new FAQ();
            GridViewRow row = (GridViewRow)gvFAQ.Rows[e.RowIndex];
            string id = gvFAQ.DataKeys[e.RowIndex].Value.ToString();
            string tID = ((TextBox)row.Cells[0].Controls[0]).Text;     
            string tTitle = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tQuestion = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tAnswer = ((TextBox)row.Cells[3].Controls[0]).Text;


            result = Faq.FAQUpdate(tID, tTitle, tQuestion, tAnswer);
            if (result > 0)
            {
                Response.Write("<script>alert('FAQ updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('FAQ NOT updated');</script>");
            }
            gvFAQ.EditIndex = -1;
            bind();
        }
    }
}