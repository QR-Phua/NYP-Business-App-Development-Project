<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="WebApp.ContactUs" %>
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
    <h2>Contact Us</h2>
    <table class="w-100">
        <tr>
            <td class="auto-style1">First Name</td>
            <td>
                <asp:TextBox ID="Tb_FirstName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="Rfv_FirstName" runat="server" ErrorMessage="First Name is required" ControlToValidate="Tb_FirstName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Last Name</td>
            <td>
                <asp:TextBox ID="Tb_LastName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="Rfv_LastName" runat="server" ErrorMessage="Last Name is required" ControlToValidate="Tb_LastName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Email</td>
            <td>
                <asp:TextBox ID="Tb_Email" runat="server" TextMode="Email"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="Rfv_Email" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="Tb_Email" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="Rev_Email" runat="server" ErrorMessage="Please enter a valid email" ControlToValidate="Tb_Email" CssClass="form-label-validator" ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+).\w+([-.]\w+)"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Mobile</td>
            <td>
                <asp:TextBox ID="Tb_Mobile" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Message</td>
            <td>
                <asp:TextBox ID="Tb_Message" runat="server" Height="55px" Width="280px" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="Rfv_Message" runat="server" ErrorMessage="Message is required" ControlToValidate="Tb_Message" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:TextBox ID="Tb_Feedback" runat="server" Height="55px" Width="280px" Rows="5" TextMode="MultiLine"></asp:TextBox>
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