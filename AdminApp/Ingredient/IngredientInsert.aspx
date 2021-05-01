<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="IngredientInsert.aspx.cs" Inherits="AdminApp.IngredientInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
        .auto-style2 {
            width: 181px;
        }
        .auto-style3 {
            height: 41px;
            width: 509px;
        }
        .auto-style4 {
            width: 841px;
        }
        .auto-style5 {
            height: 41px;
            width: 841px;
        }
        .auto-style6 {
            height: 41px;
            width: 181px;
        }
        .auto-style7 {
            width: 251px;
        }
        .auto-style8 {
            height: 41px;
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Inventory</h2>
    <table class="w-100">
        <tr>
            <td class="auto-style6">Ingredient ID</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_ingredient_ID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_ingredient_ID" runat="server" ErrorMessage="Please enter Ingredient ID" ControlToValidate="tb_ingredient_ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Ingredient Name</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_ingredient_Name" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_ingredient_Name" runat="server" ErrorMessage="Please enter a name for the ingredient" ControlToValidate="tb_ingredient_Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Supplier ID</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_suppl_ID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_suppl_ID" runat="server" ErrorMessage="Please enter Supplier ID" ControlToValidate="tb_suppl_ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Suppler Name</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_suppl_Name" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_suppl_Name" runat="server" ErrorMessage="Please enter the Supplier's name" ControlToValidate="tb_suppl_Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Description</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_description" runat="server" Height="104px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_description" runat="server" ErrorMessage="Please enter a description for the ingredient" ControlToValidate="tb_description" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Quantity</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_quantity" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_quantity" runat="server" ErrorMessage="Please enter a value for the Stock Level" ControlToValidate="tb_quantity" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td>
                <asp:CompareValidator ID="cv_quantity" runat="server" ErrorMessage="Only numeric integer is allowed" ControlToValidate="tb_quantity" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Cost Price</td>
            <td class="auto-style8">
                <asp:TextBox ID="tb_cost_Price" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="rfv_cost_Price" runat="server" ErrorMessage="Please enter the cost price of the ingredient" ControlToValidate="tb_cost_Price" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td class="auto-style1">
                <asp:CompareValidator ID="cv_cost_Price" runat="server" ErrorMessage="Only numeric value is allowed" ControlToValidate="tb_cost_Price" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Sale Price</td>
            <td class="auto-style8">
                <asp:TextBox ID="tb_sale_Price" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="rfv_sale_Price" runat="server" ErrorMessage="Please enter a sale price for the ingredient" ControlToValidate="tb_sale_Price" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td class="auto-style1">
                <asp:CompareValidator ID="cv_sale_Price" runat="server" ErrorMessage="Only numeric value is allowed" ControlToValidate="tb_sale_Price" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Level</td>
            <td class="auto-style8">
                <asp:TextBox ID="tb_level" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RequiredFieldValidator ID="rfv_level" runat="server" ErrorMessage="Please enter the level of the ingredient" ControlToValidate="tb_level" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td class="auto-style3">
                <asp:CompareValidator ID="cv_level" runat="server" ErrorMessage="Only numeric integer is allowed" ControlToValidate="tb_level" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Concern Type</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_concern_Type" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_concern_Type" runat="server" ErrorMessage="Please enter the concern types catered by the ingredient" ControlToValidate="tb_concern_Type" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Skin Type</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_skin_Type" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_skin_Type" runat="server" ErrorMessage="Please enter the skin types suitable for the ingredient" ControlToValidate="tb_skin_Type" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Sensitivity</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_sensitivity" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_sensitivity" runat="server" ErrorMessage="Please enter the sensitivity of the ingredient" ControlToValidate="tb_sensitivity" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Type</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_type" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="rfv_type" runat="server" ErrorMessage="Please enter the type of the ingredient" ControlToValidate="tb_type" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <br />
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </td>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <br />
                <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Insert" />
                <asp:Button ID="btn_IngredientView" runat="server" OnClick="btn_IngredientView_Click" Text="View Ingredient List" />
            </td>
        </tr>
    </table>
</asp:Content>
