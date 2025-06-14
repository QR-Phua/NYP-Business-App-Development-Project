﻿using System;
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
                    if (Session["CustomerID"] != null)
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



                            lbl_Subtotal.Text = "Subtotal Amount: $" + amount.ToString();

                            float taxes = (float)(amount * 0.07);
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
                            btn_BackProductFormulation.Visible = false;
                            btn_CheckOut.Visible = false;
                        }
                    }
                    else
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



                        lbl_Subtotal.Text = "Subtotal Amount: $" + amount.ToString();

                        float taxes = (float)(amount * 0.07);
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
                        btn_CheckOut.Visible = false;
                    }
                }

            }

        }

        public bool refreshData()
        {
            

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            DataTable dt;

            if (cart == null)
            {
                cart = new ShoppingCart();
                string custID = Session["CustomerID"].ToString();
                cart.custID = custID;
                cart.SignedRetrieveCartID();
                dt = cart.SignedIngredientPageRetrieve();

                foreach (DataRow row in dt.Rows)
                {
                    if (row["type"].ToString() == "Cleanser"){
                        cart.cleanserQuantity = (int)row["quantity"];
                    }
                    else if (row["type"].ToString() == "Toner-Serum")
                    {
                        cart.tonerQuantity = (int)row["quantity"];
                    }
                    else if (row["type"].ToString() == "Moisturiser")
                    {
                        cart.moisturiserQuantity = (int)row["quantity"];
                    }
                }

                Session["CartObject"] = cart;

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
            

            // Check if customer is signed in 

            if (Session["CustomerID"] != null)
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
            

            GridViewRow row = (GridViewRow)CartList.Rows[e.RowIndex];
            string type = row.Cells[0].Text;

            ShoppingCart cart = (ShoppingCart)Session["CartObject"];

            bool result = false; ;

            //Check if signed in

            if (Session["CustomerID"] != null)
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
                    Session.Remove("CleanserQuantity");
                    Session["CartObject"] = cart;
                    Response.Redirect("ShoppingCart.aspx");
                }
                else if (type == "Moisturiser")
                {
                    cart.moisturiserQuantity = 0;
                    cookie["MoisturiserQuantity"] = cart.moisturiserQuantity.ToString();
                    Response.Cookies.Add(cookie);
                    Session.Remove("MoisturiserQuantity");
                    Session["CartObject"] = cart;
                    Response.Redirect("ShoppingCart.aspx");
                }
                else if (type == "Toner-Serum")
                {
                    cart.tonerQuantity = 0;
                    cookie["TonerQuantity"] = cart.tonerQuantity.ToString();
                    Response.Cookies.Add(cookie);
                    Session.Remove("TonerQuantity");
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
                else if (type == "Toner-Serum")
                {
                    cookie["TonerQuantity"] = quantity.ToString();
                    cart.tonerQuantity = quantity;
                }
                else if (type == "Moisturiser")
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
            if (Session["CustomerID"] == null)
            {
                Response.Write(@"<script language='javascript'>alert('You need to sign in!');</script>");
                Response.Redirect("~/Shopping Cart/ShoppingCart.aspx");
            }


            ShoppingCart cart = (ShoppingCart)Session["CartObject"];
            cart.SignedDeleteAllCartItem();
            cart.SignedDeleteCart();

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