using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab06
{


    public partial class CustOrdersDetails : System.Web.UI.Page
    {

        OrderDetails aOrder = new OrderDetails();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bind();
            }


        }

        protected void bind()
        {

            string payID = Request.QueryString["PayID"].ToString();

            

            List<OrderDetails> orderList = new List<OrderDetails>();
            orderList = aOrder.getOrderDetailsAll();
            gvOrders.DataSource = orderList;
            gvOrders.DataBind();
        }


        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustOrders.aspx?");
        }
    }   
}