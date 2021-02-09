<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffLogin.aspx.cs" Inherits="WebApp.staffLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2">Staff Login</td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="staff_username" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="staff_password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="staff_login" runat="server" Text="Login" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
