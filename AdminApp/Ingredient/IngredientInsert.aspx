<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="IngredientInsert.aspx.cs" Inherits="AdminApp.IngredientInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style1 {
            width: 150px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">Ingredient ID</td>
            <td>
                <asp:TextBox ID="tb_ingredient_ID" runat="server" Width="216px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Ingredient Name</td>
            <td>
                <asp:TextBox ID="tb_ingredient_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Supplier ID</td>
            <td>
                <asp:TextBox ID="tb_suppl_ID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Supplier Name</td>
            <td>
                <asp:TextBox ID="tb_suppl_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Description</td>
            <td>
                <asp:TextBox ID="tb_description" runat="server" Height="92px" Width="318px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Quantity</td>
            <td>
                <asp:TextBox ID="tb_quantity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Cost Price</td>
            <td>
                <asp:TextBox ID="tb_cost_Price" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Sale Price</td>
            <td>
                <asp:TextBox ID="tb_sale_Price" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Level</td>
            <td>
                <asp:TextBox ID="tb_level" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Concern Type</td>
            <td>
                <asp:TextBox ID="tb_concern_Type" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Insert" />
                <asp:Button ID="btn_IngredientView" runat="server" OnClick="btn_IngredientView_Click" Text="View Ingredient List" />
            </td>
        </tr>
    </table>
</asp:Content>
