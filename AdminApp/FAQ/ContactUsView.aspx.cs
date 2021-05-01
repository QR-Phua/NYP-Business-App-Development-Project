using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class ContactUsView : System.Web.UI.Page
    {   /*
        ContactUs aContactus = new ContactUs();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bind();
            }

        }
        protected void bind()
        {
            List<ContactUs> ContactUsList = new List<ContactUs>();
            ContactUsList = aContactus.getcontactusall();
            gvContactUs.DataSource = ContactusList;
            gvContactUs.DataBind();
        }

        protected void gvContactUs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvContactUs.SelectedRow;

            string ContactUs_ID = row.Cells[0].Text;

            Response.Redirect("ContactUsDetails.aspx?ContactUs_ID=" + ContactUs_ID);
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Changes save succesfully');</script>");
        }

        protected void gvContactUs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            ContactUs contactus = new ContactUs();
            string categoryID = gvContactUs.DataKeys[e.RowIndex].Value.ToString();
            result = Contactus.ContactUsDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Removal NOT successful');</script>");
            }

            Response.Redirect("ContactUsView.aspx");
        }

        protected void gvContactUs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvContactUs.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvContactUs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvContactUs.EditIndex = -1;
            bind();
        }

        protected void gvv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            ContactUs Contactus = new ContactUs();
            GridViewRow row = (GridViewRow)gvContactUs.Rows[e.RowIndex];
            string id = gvFAQ.DataKeys[e.RowIndex].Value.ToString();
            string cID = ((TextBox)row.Cells[0].Controls[0]).Text;
            string cFirstName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string cLastName = ((TextBox)row.Cells[2].Controls[0]).Text;
            string cEmail = ((TextBox)row.Cells[3].Controls[0]).Text;
            int cMobile = ((TextBox)row.Cells[4].Controls[0]).Text;
            string cMessage = ((TextBox)row.Cells[6].Controls[0]).Text;
            string cProdName = ((TextBox)row.Cells[7].Controls[0]).Text;
            string cFeedback = ((TextBox)row.Cells[8].Controls[0]).Text;


            result = Contactus.ContactUsUpdate(cID, cFirstName, cLastName, cEmail, cMobile, cMessage, cProdName, cFeedback);
            if (result > 0)
            {
                Response.Write("<script>alert('Updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('NOT updated');</script>");
            }
            gvContactUs.EditIndex = -1;
            bind();
        }
        */
    }
}