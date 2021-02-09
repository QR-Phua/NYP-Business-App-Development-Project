using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CustOrders : System.Web.UI.Page

    {
        PaymentDetails aPay = new PaymentDetails();
        Customer aRE = new Customer();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
                
        }

        protected void bind()
        {
            List<PaymentDetails> payList = new List<PaymentDetails>();
            payList = aPay.getPaymentDetailsAll();


            gvPayment.DataSource = payList;
            gvPayment.DataBind();

            aRE = aRE.getCustDetails("1");

            lbl_CustID.Text = aRE.CustomerID;
            lbl_CustName.Text = aRE.CustomerName;
            lbl_CustAddr.Text = aRE.CustomerAddress;
            lbl_CustEmail.Text = aRE.CustomerEmail;
            lbl_CustPhone.Text = aRE.CustomerPhone;
        }

        protected void gvPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPayment.SelectedRow;

            string payID = row.Cells[0].Text;

            Response.Redirect("CustOrdersDetails.aspx?PayID=" + payID);

        }




    }
}