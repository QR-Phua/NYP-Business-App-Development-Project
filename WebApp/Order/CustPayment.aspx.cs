using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CustPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();

            }
        }

        protected void LoadCart()
        {
            //bind the Items inside the Session/ShoppingCart Instance with the Datagrid
            gv_CartView.DataSource = ShoppingCart.Instance.Items;
            gv_CartView.DataBind();

            decimal total = 0.0m;
            foreach (ShoppingCartItem item in ShoppingCart.Instance.Items)
            {
                total = total + item.TotalPrice;
            }
            lbl_TotalPrice.Text = total.ToString();

        }


        protected void btn_Order_Click(object sender, EventArgs e)
        {
            int result = 0;

            PaymentDetails pDetail = new PaymentDetails(tb_PaymentID.Text, tb_CustID.Text,tb_Date.Text, ddl_PType.Text,ddl_Status.Text);
            result = pDetail.PaymentInsert();

            if (result > 0)
            {
                Response.Write("<script>alert('Insert successful');</script>");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }

            Response.Redirect("CustOrders.aspx");

        }


    }
    
}