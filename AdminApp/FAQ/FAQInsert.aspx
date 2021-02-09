<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="FAQInsert.aspx.cs" Inherits="AdminApp.FAQInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 159px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>FAQ</h2>
    <p>
        <table class="w-100">
            <tr>
                <td class="auto-style1">Faq ID</td>
                <td>
                    <asp:TextBox ID="tb_faq_ID" runat="server" Width="216px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Faq Title</td>
                <td>
                    <asp:TextBox ID="tb_faq_Title" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Faq Question</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tb_faq_Question" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Faq Answer</td>
                <td>
                    <asp:TextBox ID="tb_faq_Answer" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btn_Insert" runat="server" OnClick="btn_Insert_Click" Text="Insert" />
                    <asp:Button ID="btn_FaqView" runat="server" OnClick="btn_FaqView_Click" Text="View FAQ List" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
