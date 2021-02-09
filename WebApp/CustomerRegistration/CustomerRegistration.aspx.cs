using Lab06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    protected void Customer_register_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";


            Customer customer = new Customer(cust_fname.Text, cust_lname.Text, cust_password.Text,
                cust_gender.Text, cust_email.Text, cust_hp.Text, cust_add.Text, cust_payment.Text);
            result = customer.CustomerInsert();

            if (result > 0)
            {
              
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Write("<script>alert('Insert successful');</script>");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
        }
    }
}