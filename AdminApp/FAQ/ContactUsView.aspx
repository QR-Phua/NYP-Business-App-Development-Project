<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ContactUsView.aspx.cs" Inherits="AdminApp.ContactUsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Contact Us</h2>
    <asp:GridView ID="gvContactUs" runat="server" AutoGenerateColumns="False" DataKeyNames="ContactUs_ID" OnRowCancelingEdit="gvContactUs_RowCancelingEdit" OnRowDeleting="gvContactUs_RowDeleting" OnRowEditing="gvContactUs_RowEditing" OnRowUpdating="gvContactUs_RowUpdating" OnSelectedIndexChanged="gvContactUs_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ContactUs_ID" HeaderText="Contact Us ID" />
            <asp:BoundField DataField="ContactUs_FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="ContactUs_LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="ContactUs_Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactUs_Mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="ContactUs_Message" HeaderText="Message" />
            <asp:BoundField DataField="ContactUs_ProdName" HeaderText="Product Name" />
            <asp:BoundField DataField="ContactUs_Feedback" HeaderText="Feedback" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" Text="Save " />
</asp:Content>