using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class IngredientDetails : System.Web.UI.Page
    {
        Ingredient Igd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Ingredient aIgd = new Ingredient();
            // Get Ingredient ID from querystring
            string ingredient_ID = Request.QueryString["ingredient_ID"].ToString();
            Debug.WriteLine(ingredient_ID);
            Igd = aIgd.getIngredient(ingredient_ID);

            lbl_ingredient_Name.Text = Igd.ingredient_Name;
            lbl_suppl_Name.Text = Igd.suppl_Name;
            lbl_description.Text = Igd.description;
            lbl_quantity.Text = Igd.quantity.ToString("c");
            lbl_cost_Price.Text = Igd.cost_Price.ToString("c");
            lbl_sale_Price.Text = Igd.sale_Price.ToString("c");
            lbl_level.Text = Igd.level.ToString("c");
            lbl_concern_Type.Text = Igd.concern_Type;
            
            lbl_ingredient_ID.Text = "(" + ingredient_ID.ToString() + ")";

        }

        protected void btn_IngredientView_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngredientView.aspx");
        }

    }
}