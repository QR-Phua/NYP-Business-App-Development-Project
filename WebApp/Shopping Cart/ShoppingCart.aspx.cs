using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp.Shopping_Cart
{
    public partial class CartPage : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
               
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["cartInfo"] == null)
                {
                    lbl_Nothing.Visible = true;
                    lbl_Nothing.Text = "There is nothing in your Shopping Cart!";
                    lbl_Nothing.Attributes.CssStyle.Add("font-size", "30px");
                    lbl_Subtotal.Visible = false;
                    lbl_Taxes.Visible = false;
                    lbl_Total.Visible = false;
                    btn_BackProductFormulation.Visible = false;
                    btn_CheckOut.Visible = false;
                }

                else
                {
                    bool result = refreshData();
                    if (result)
                    {
                        ShoppingCart cart = (ShoppingCart)Session["CartObject"];

                        float amount = 0;

                        if (cart.cleanserQuantity > 0)
                        {
                            amount += (float)(cart.cleanserQuantity * 19.00);
                        }
                        
                        if (cart.tonerQuantity > 0)
                        {
                            amount += (float)(cart.tonerQuantity * 29.00);
                        }
                        
                        if (cart.moisturiserQuantity > 0)
                        {
                            amount += (float)(cart.moisturiserQuantity * 29.00);
                        }
                        else
                        

                        lbl_Subtotal.Text = "Subtotal Amount: $" + amount.ToString();

                        float taxes = (float)(amount * 1.07);
                        lbl_Taxes.Text = "Estimated Taxes: $" + taxes.ToString();

                        lbl_Total.Text = "Total Amount: $" + (amount + taxes).ToString();
                        lbl_Nothing.Visible = false;
                    }

                    else
                    {
                        lbl_Nothing.Visible = true;
                        lbl_Nothing.Text = "There is nothing in your Shopping Cart!";
                        lbl_Nothing.Attributes.CssStyle.Add("font-size", "30px");
                        lbl_Subtotal.Visible = false;
                        lbl_Taxes.Visible = false;
                        lbl_Total.Visible = false;
                    }
                }
                
            }
            
        }

        public bool refreshData()
        {
            HttpCookie cookie = Request.Cookies["cartInfo"];
            string cart_ID = cookie["UnsignedCartID"];

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];
            DataTable dt;

            // Check if customer is signed in 

            if (Session["Customer"] != null)
            {
                dt = cart.SignedIngredientPageRetrieve();
            }
            else
            {
                dt = cart.IngredientPageRetrieve();
            }
           
            CartList.DataSource = dt;
            CartList.DataBind();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
               
        protected void CartList_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cartInfo"];
            string cart_ID = cookie["UnsignedCartID"];

            GridViewRow row = (GridViewRow)CartList.Rows[e.RowIndex];
            string type = row.Cells[0].Text;

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            bool result = false; ;

            //Check if signed in

            if (Session["Customer"] != null)
            {
                result = cart.SignedCartDelete(type);
            }

            else
            {
                result = cart.CartDelete(type);
            }
            
            if (result)
            {
                
                if (type == "Cleanser")
                {
                    
                    cart.cleanserQuantity = 0;
                    cookie["CleanserQuantity"] = cart.cleanserQuantity.ToString();
                    Response.Cookies.Add(cookie);
                    Session["CartObject"] = cart;
                    Response.Redirect("ShoppingCart.aspx");
                }
                else if (type == "Moisturiser")
                {
                    cart.moisturiserQuantity = 0;
                    cookie["MoisturiserQuantity"] = cart.moisturiserQuantity.ToString();
                    Response.Cookies.Add(cookie);
                    Session["CartObject"] = cart;
                    Response.Redirect("ShoppingCart.aspx");
                }
                else if (type == "Toner-Serum")
                {
                    cart.tonerQuantity = 0;
                    cookie["TonerQuantity"] = cart.tonerQuantity.ToString();
                    Response.Cookies.Add(cookie);
                    Session["CartObject"] = cart;
                    Response.Redirect("ShoppingCart.aspx");
                }
                else
                {

                }
               
            }
            else
            {
                Debug.WriteLine("DELETE UNSUCCESSFUL! ");
            }
        }

        protected void ddl_Quantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("IN QUANTITY SELECTED INDEX CHANGED");
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int index = row.RowIndex;
            GridViewRow selected = CartList.Rows[index];
            string type = selected.Cells[0].Text;

            HttpCookie cookie = Request.Cookies["cartInfo"];
            string cart_ID = cookie["UnsignedCartID"];
            
            int quantity = int.Parse(ddl.SelectedValue);

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            bool result = false;
            //Check if signed in 
            if (Session["Customer"] != null)
            {
                result = cart.SignedCartUpdate(type, quantity);
            }
            else
            {
                result = cart.CartUpdate(type, quantity);
            }

            
            if (result)
            {
                Debug.WriteLine("UPDATE SUCCESSFUL! ");

                if (type == "Cleanser")
                {
                    cookie["CleanserQuantity"] = quantity.ToString();
                    cart.cleanserQuantity = quantity;
                    
                }
                else if (type == "Toner")
                {
                    cookie["TonerQuantity"] = quantity.ToString();
                    cart.tonerQuantity = quantity;
                }
                else
                {
                    cookie["MoisturiserQuantity"] = quantity.ToString();
                    cart.moisturiserQuantity = quantity;
                }
                
                Response.Cookies.Add(cookie);
                Session["CartObject"] = cart;
                Response.Redirect("ShoppingCart.aspx");
            }
            else
            {
                Debug.WriteLine("UPDATE UNSUCCESSFUL! ");
            }
        }

        protected void btn_BackProductFormulation_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductFormulation.aspx");
        }

        protected void btn_CheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOMEWHERE");
        }
    }
}