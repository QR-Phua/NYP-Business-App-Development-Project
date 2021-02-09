<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffRegistration.aspx.cs" Inherits="WebApp.staffRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td colspan="2">Staff Registration</td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:TextBox ID="staff_fname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td>
                    <asp:TextBox ID="staff_lname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="staff_password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="staff_username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="staff_email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contact No.:</td>
                <td>
                    <asp:TextBox ID="staff_hp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Role:</td>
                <td>
                    <asp:DropDownList ID="staff_role" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="staff_reg" runat="server" Text="Register" Width="152px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
