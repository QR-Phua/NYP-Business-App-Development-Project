<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ContactUsView.aspx.cs" Inherits="WebApp.ContactUsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
            height: 42px;
        }
        .auto-style3 {
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <p>Contact Us</p>
    <table cellpadding="2" class="w-100">
        <tr>
            <td class="auto-style1">First Name</td>
            <td>
                <asp:TextBox ID="Tb_FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Last Name</td>
            <td>
                <asp:TextBox ID="Tb_LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email</td>
            <td>
                <asp:TextBox ID="Tb_Email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Mobile</td>
            <td>
                <asp:TextBox ID="Tb_Mobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Message</td>
            <td>
                <asp:TextBox ID="Tb_Message" runat="server" Height="56px" Width="282px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">For specific product&#39;s feedback, please fill in the fields below as well as the fields above.</td>
        </tr>
        <tr>
            <td class="auto-style1">Product Name</td>
            <td>
                <asp:TextBox ID="Tb_ProductName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Feedback</td>
            <td rowspan="2">
                <asp:TextBox ID="Tb_Feedback" runat="server" Height="56px" Width="282px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Submit" />
            </td>
        </tr>
    </table>
</asp:Content>