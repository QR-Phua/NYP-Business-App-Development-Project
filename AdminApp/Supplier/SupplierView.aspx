<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="SupplierView.aspx.cs" Inherits="AdminApp.SupplierView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvSupplier" runat="server" AutoGenerateColumns="False" DataKeyNames="suppl_ID" OnRowCancelingEdit="gvSupplier_RowCancelingEdit" OnRowDeleting="gvSupplier_RowDeleting" OnRowEditing="gvSupplier_RowEditing" OnRowUpdating="gvSupplier_RowUpdating">
        <Columns>
            <asp:BoundField DataField="suppl_ID" HeaderText="Supplier ID" ReadOnly = "true"/>
            <asp:BoundField DataField="suppl_Name" HeaderText="Supplier Name" />
            <asp:BoundField DataField="suppl_Contact" HeaderText="Contact" />
            <asp:BoundField DataField="suppl_Email" HeaderText="Email" />
            <asp:BoundField DataField="suppl_Address" HeaderText="Address" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btn_AddSupplier" runat="server" OnClick="btn_AddSupplier_Click" Text="Add New Supplier" />
    <br />
</asp:Content>
