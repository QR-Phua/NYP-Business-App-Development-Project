using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApp
{
    public partial class IngredientView : System.Web.UI.Page
    {
        Ingredient aIgd = new Ingredient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

        }
        protected void bind()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            ingredientList = aIgd.getIngredientAll();
            gvIngredient.DataSource = ingredientList;
            gvIngredient.DataBind();
        }

        protected void gvIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvIngredient.SelectedRow;

            // Get Ingredient ID from the selected row, which is the 
            // first row, i.e. index 0.
            string ingredient_ID = row.Cells[0].Text;

            // Redirect to next page, with the Ingredient Id added to the URL,
            // e.g. IngredienttDetails.aspx?IgdID=1
            Response.Redirect("IngredientDetails.aspx?ingredient_ID=" + ingredient_ID);
        }

        protected void btn_AddIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngredientInsert.aspx");
        }

        protected void gvIngredient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Ingredient Igd = new Ingredient();
            string categoryID = gvIngredient.DataKeys[e.RowIndex].Value.ToString();
            result = Igd.IngredientDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Ingredient Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Ingredient Removal NOT successfully');</script>");
            }

            Response.Redirect("IngredientView.aspx");
        }

        protected void gvIngredient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIngredient.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvIngredient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIngredient.EditIndex = -1;
            bind();
        }

        protected void gvIngredient_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Ingredient Igd = new Ingredient();
            GridViewRow row = (GridViewRow)gvIngredient.Rows[e.RowIndex];
            string id = gvIngredient.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tquantity = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tsupplier = ((TextBox)row.Cells[2].Controls[0]).Text;

            result = Igd.IngredientUpdate(tid, int.Parse(tquantity), tsupplier);
            if (result > 0)
            {
                Response.Write("<script>alert('Ingredient updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Ingredient NOT updated');</script>");
            }
            gvIngredient.EditIndex = -1;
            bind();
        }
    }
}