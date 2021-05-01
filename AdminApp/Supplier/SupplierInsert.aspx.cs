using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class SupplierInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;

            Supplier sup = new Supplier(tb_suppl_ID.Text, tb_suppl_Name.Text, tb_suppl_Contact.Text, tb_suppl_Email.Text, tb_suppl_Address.Text);
            result = sup.SupplierInsert();

            if (result > 0)
            {
                Response.Write("<script>alert('Insert successful');</script>");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
        }

        protected void btn_SupplierView_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierView.aspx");
        }
    }
}