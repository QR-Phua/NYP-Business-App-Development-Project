<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustOrders.aspx.cs" Inherits="Lab06.CustOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your Payments</p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvPayment" runat="server" AutoGenerateColumns="False" Width="802px" OnSelectedIndexChanged="gvPayment_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Payment_ID" HeaderText="Payment ID" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                <asp:BoundField DataField="PaymentType" HeaderText="Payment Type" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">Customer ID:</td>
                    <td>
                        <asp:Label ID="lbl_CustID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Customer Name :</td>
                    <td>
                        <asp:Label ID="lbl_CustName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Customer Address :</td>
                    <td>
                        <asp:Label ID="lbl_CustAddr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Customer Email :</td>
                    <td>
                        <asp:Label ID="lbl_CustEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Customer Phone :</td>
                    <td>
                        <asp:Label ID="lbl_CustPhone" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
</asp:Content>
