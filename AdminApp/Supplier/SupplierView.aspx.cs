using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class SupplierView : System.Web.UI.Page
    {
        Supplier aSup = new Supplier();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            List<Supplier> supList = new List<Supplier>();
            supList = aSup.getSupplierAll();
            gvSupplier.DataSource = supList;
            gvSupplier.DataBind();
        }


        protected void btn_AddSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierInsert.aspx");
        }

        protected void gvSupplier_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Supplier sup = new Supplier();
            GridViewRow row = (GridViewRow)gvSupplier.Rows[e.RowIndex];
            string id = gvSupplier.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tcontact = ((TextBox)row.Cells[2].Controls[0]).Text;
            string temail = ((TextBox)row.Cells[3].Controls[0]).Text;
            string taddress = ((TextBox)row.Cells[4].Controls[0]).Text;

            result = sup.SupplierUpdate(tid, tname, tcontact, temail, taddress);
            if (result > 0)
            {
                Response.Write("<script>alert('Supplier updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Supplier NOT updated');</script>");
            }
            gvSupplier.EditIndex = -1;
            bind();
        }

        protected void gvSupplier_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSupplier.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Supplier sup = new Supplier();
            string categoryID = gvSupplier.DataKeys[e.RowIndex].Value.ToString();
            result = sup.SupplierDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Supplier Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Supplier Removal NOT successfully');</script>");
            }

            Response.Redirect("SupplierView.aspx");
        }

        protected void gvSupplier_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSupplier.EditIndex = -1;
            bind();
        }
    }
}