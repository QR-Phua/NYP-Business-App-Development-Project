<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="FAQView.aspx.cs" Inherits="AdminApp.FAQView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Frequently Asked Question</h2>
    <asp:GridView ID="gvFAQ" runat="server" AutoGenerateColumns="False" DataKeyNames="faq_ID" OnRowCancelingEdit="gvFAQ_RowCancelingEdit" OnRowDeleting="gvFAQ_RowDeleting" OnRowEditing="gvFAQ_RowEditing" OnRowUpdating="gvFAQ_RowUpdating" OnSelectedIndexChanged="gvFAQ_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="faq_ID" HeaderText="FAQ ID" />
            <asp:BoundField DataField="faq_Title" HeaderText="Title" />
            <asp:BoundField DataField="faq_Question" HeaderText="Question" />
            <asp:BoundField DataField="faq_Answer" HeaderText="Answer" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_AddFaq" runat="server" OnClick="btn_AddFaq_Click" Text="Add New FAQ" />
</asp:Content>
