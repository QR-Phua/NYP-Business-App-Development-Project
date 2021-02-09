<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="CustPayment.aspx.cs" Inherits="WebApp.CustPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 79px;
        }
        .auto-style4 {
            width: 259px;
        }
        .auto-style5 {
            width: 163px;
        }
        .auto-style6 {
            width: 85px;
        }
        .auto-style7 {
            width: 79px;
            height: 29px;
        }
        .auto-style8 {
            height: 29px;
        }
        .auto-style9 {
            width: 304px;
        }
        .auto-style10 {
            height: 29px;
            width: 304px;
        }
        .auto-style14 {
            width: 79px;
            height: 68px;
        }
        .auto-style15 {
            width: 304px;
            height: 68px;
        }
        .auto-style16 {
            height: 68px;
        }
        .auto-style17 {
            width: 79px;
            height: 80px;
        }
        .auto-style18 {
            width: 304px;
            height: 80px;
        }
        .auto-style19 {
            height: 80px;
        }
        .auto-style20 {
            width: 79px;
            height: 37px;
        }
        .auto-style21 {
            width: 304px;
            height: 37px;
        }
        .auto-style22 {
            height: 37px;
        }
        .auto-style23 {
            width: 259px;
            height: 9px;
        }
        .auto-style24 {
            width: 163px;
            height: 9px;
        }
        .auto-style25 {
            height: 9px;
        }
        .auto-style26 {
            width: 79px;
            height: 10px;
        }
        .auto-style27 {
            width: 304px;
            height: 10px;
        }
        .auto-style28 {
            height: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        CheckOut</p>
    <table class="auto-style2">
        <tr>
            <td class="auto-style14">Payment ID:</td>
            <td class="auto-style15">
                <asp:TextBox ID="tb_PaymentID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style17">Customer ID :</td>
            <td class="auto-style18">
                <asp:TextBox ID="tb_CustID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style19">
<asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID">
    <Columns>
        <asp:BoundField DataField="ItemID" HeaderText="Product ID" />
        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HeaderText="Unit_Price" />
        <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="Price" />
    </Columns>
</asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style20">Date :</td>
            <td class="auto-style21">
                <asp:TextBox ID="tb_Date" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style22">
<asp:Label ID="lbl_Error" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Payment Type :</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddl_PType" runat="server">
                    <asp:ListItem>Credit Card</asp:ListItem>
                    <asp:ListItem>Debit Card</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Status :</td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddl_Status" runat="server">
                    <asp:ListItem>Pending</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style26">Card Type:</td>
            <td class="auto-style27">
                <br />
                <asp:DropDownList ID="DropDownList3" runat="server">
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style28"></td>
        </tr>
        </table>
    <table class="auto-style2">
        <tr>
            <td class="auto-style4">Card Number :</td>
            <td class="auto-style5">Expiry Month:</td>
            <td>Expiry Year:</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="tb_CNumber" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">Name on Card :</td>
            <td class="auto-style24">CVV :</td>
            <td class="auto-style25"></td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:TextBox ID="tb_CName" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="tb_CVV" runat="server" Width="92px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    Order Summary<br />
    <br />
    <table class="auto-style2">
        <tr>
            <td class="auto-style6">SubTotal :</td>
            <td>
                $
                <asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Shipping Fee :</td>
            <td>
                $
                <asp:Label ID="lbl_Ship" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Total Price :</td>
            <td>
                $
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btn_Order" runat="server" OnClick="btn_Order_Click" Text="Place Order" />
</asp:Content>
