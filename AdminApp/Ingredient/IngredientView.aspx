<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="IngredientView.aspx.cs" Inherits="AdminApp.IngredientView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Inventory</h2>
    <asp:GridView ID="gvIngredient" runat="server" AutoGenerateColumns="False" DataKeyNames="ingredient_ID" OnRowCancelingEdit="gvIngredient_RowCancelingEdit" OnRowDeleting="gvIngredient_RowDeleting" OnRowEditing="gvIngredient_RowEditing" OnRowUpdating="gvIngredient_RowUpdating" OnSelectedIndexChanged="gvIngredient_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ingredient_Name" HeaderText="Ingredient" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="suppl_Name" HeaderText="Supplier" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_AddIngredient" runat="server" OnClick="btn_AddIngredient_Click" Text="Add New Ingredient" />
</asp:Content>
