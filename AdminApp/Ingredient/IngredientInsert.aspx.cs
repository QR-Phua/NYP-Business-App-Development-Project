using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class IngredientInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;

            Ingredient Igd = new Ingredient(tb_ingredient_ID.Text, tb_ingredient_Name.Text, tb_suppl_ID.Text, tb_suppl_Name.Text, tb_description.Text, int.Parse(tb_quantity.Text),
                 decimal.Parse(tb_cost_Price.Text), decimal.Parse(tb_sale_Price.Text), int.Parse(tb_level.Text), tb_concern_Type.Text, tb_skin_Type.Text, tb_sensitivity.Text, tb_type.Text);


            result = Igd.IngredientInsert();

            if (result > 0)
            {

                Response.Write("<script>alert('Insert successful');</script>");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }
        }

        protected void btn_IngredientView_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngredientView.aspx");
        }
    }
}