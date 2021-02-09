<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="IngredientDetails.aspx.cs" Inherits="AdminApp.IngredientDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 61%;
            margin-right: 96px;
        }
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
            width: 132px;
        }
        .auto-style5 {
            width: 132px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingredient Details</h2>
    <table class="auto-style2">
        <tr>
            <td class="auto-style4">
                Ingredient ID</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_ingredient_ID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Ingredient Name</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_ingredient_Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Supplier</td>
            <td>
                <asp:Label ID="lbl_suppl_Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Description</td>
            <td>
                <asp:Label ID="lbl_description" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Quantity</td>
            <td>
                <asp:Label ID="lbl_quantity" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Cost Price</td>
            <td>
                <asp:Label ID="lbl_cost_Price" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Sale Price</td>
            <td>
                <asp:Label ID="lbl_sale_Price" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Level</td>
            <td>
                <asp:Label ID="lbl_level" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                Concern Type</td>
            <td>
                <asp:Label ID="lbl_concern_Type" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_IngredientView" runat="server" OnClick="btn_IngredientView_Click" Text="Back" />
            </td>
        </tr>
    </table>
</asp:Content>
