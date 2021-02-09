<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustOrdersDetails.aspx.cs" Inherits="Lab06.CustOrdersDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    ORDER DETAILS</p>
<p>
    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
            <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
            <asp:BoundField DataField="Product_Desc" HeaderText="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Unit_Price" DataFormatString="{0:C}" HeaderText="Unit Price" />
        </Columns>
    </asp:GridView>
</p>
    <p>
Total Price =
    $
</p>
    <p>
        <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back " />
</p>
</asp:Content>
