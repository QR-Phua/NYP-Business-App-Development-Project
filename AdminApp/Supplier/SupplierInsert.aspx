<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="SupplierInsert.aspx.cs" Inherits="AdminApp.SupplierInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 164px;
        }
        .auto-style2 {
            width: 332px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Supplier&nbsp;&nbsp; </h2>
    <table class="w-100">
        <tr>
            <td class="auto-style1">Supplier ID</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_suppl_ID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_suppl_ID" runat="server" ControlToValidate="tb_suppl_ID" ErrorMessage="Please enter Supplier ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Supplier Name</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_suppl_Name" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_suppl_Name" runat="server" ControlToValidate="tb_suppl_Name" ErrorMessage="Please enter the Supplier's Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Contact</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_suppl_Contact" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_suppl_Contact" runat="server" ControlToValidate="tb_suppl_Contact" ErrorMessage="Please enter the Supplier's number" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_suppl_Email" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_suppl_Email" runat="server" ControlToValidate="tb_suppl_Email" ErrorMessage="Please enter the Supplier's email" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Address</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_suppl_Address" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_suppl_Address" runat="server" ControlToValidate="tb_suppl_Address" ErrorMessage="Please enter the Supplier's address" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Result" runat="server" Text="Label"></asp:Label>
            </td>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <br />
                <asp:Button ID="btn_Insert" runat="server" Text="Insert" OnClick="btn_Insert_Click" />
                <asp:Button ID="btn_SupplierView" runat="server" Text="View Supplier List" OnClick="btn_SupplierView_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
