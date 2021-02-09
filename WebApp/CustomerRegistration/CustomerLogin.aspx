<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="WebApp.CustomerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2">Customer Login</td>
                </tr>
                <tr>
                    <td class="auto-style2">Email:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="cust_email" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="cust_password" runat="server" Width="159px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="button_GoToLogin" runat="server" Text="Login" Width="259px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
