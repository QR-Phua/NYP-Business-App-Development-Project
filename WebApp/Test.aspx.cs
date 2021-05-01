using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null)
            {
                Session["CustomerID"] = "1";

                if (Session["CartObject"] != null)
                {
                    ShoppingCart cart = (ShoppingCart)Session["CartObject"];
                    cart.custID = Session["CustomerID"].ToString();

                    bool result = cart.transferUnsignedToSigned();
                    if (result)
                    {
                        Debug.WriteLine("DONE TRANSFERRING");
                    }
                    else
                    {
                        Debug.WriteLine("TRANSFER NOT SUCCESSFUL!");
                    }

                    Session["CartObject"] = cart;
                }

                Response.Redirect("~/Shopping Cart/ShoppingCart.aspx");
            }
            else
            {
                //Session["CustomerID"] = null;
                Session.Abandon();

                if (Request.Cookies["QuizResult"] != null)
                {
                    Response.Cookies["QuizResult"].Expires = DateTime.Now.AddDays(-1);
                }

                if (Request.Cookies["cartInfo"] != null)
                {
                    Response.Cookies["cartInfo"].Expires = DateTime.Now.AddDays(-1);
                }

                Response.Redirect("~/Shopping Cart/ShoppingCart.aspx");

            }

        }
    }
}