<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="WebApp.CustomerRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td colspan="2">Customer Registration</td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox ID="cust_fname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox ID="cust_lname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="cust_password" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Gender:</td>
                <td>
                    <asp:DropDownList ID="cust_gender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="cust_email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone Number:</td>
                <td>
                    <asp:TextBox ID="cust_hp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address:</td>
                <td>
                    <asp:TextBox ID="cust_add" runat="server" Width="201px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Payment Method:</td>
                <td>
                    <asp:DropDownList ID="cust_payment" runat="server">
                        <asp:ListItem>PayPal</asp:ListItem>
                        <asp:ListItem>Mastercard</asp:ListItem>
                        <asp:ListItem>Visa</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Customer_register" runat="server" Text="CustomerRegister" Width="238px" OnClick="Customer_register_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
