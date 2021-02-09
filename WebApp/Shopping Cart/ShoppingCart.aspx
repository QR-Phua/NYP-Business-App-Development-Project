<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebApp.Shopping_Cart.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <div class="container">
        <div class="row justify-content-center" >
            <h3>Shopping Cart</h3>
        </div>
        <br />
        <br />
        <span style="text-align: center; align-content:center;"><asp:Label ID="lbl_Nothing" runat="server" Text="" ></asp:Label></span>
        <br />
        <div class="row justify-content-center">
            <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" GridLines="Vertical" CellPadding="4"
                CssClass="table table-striped table-bordered"  OnRowDeleting="CartList_RowDeleting1" >
                <Columns>
                    <asp:BoundField DataField="type" HeaderText="Product Name" />
                    <asp:BoundField DataField="price" HeaderText="Price" />

                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddl_Quantity" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_Quantity_SelectedIndexChanged" SelectedValue='<% #Eval("quantity") %>'>
                                <asp:ListItem Value=1>1</asp:ListItem>
                                <asp:ListItem Value=2>2</asp:ListItem>
                                <asp:ListItem Value=3>3</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btn_Delete" Class="btn btn-danger" runat="server" Text="Remove Item" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <hr />
        <div class="row justify-content-end">
            <asp:Label ID="lbl_Subtotal" runat="server" Text="" CssClass="h4"></asp:Label>
        </div>
        <div class="row justify-content-end">
            <asp:Label ID="lbl_Taxes" runat="server" Text="" CssClass="h4"></asp:Label>
        </div>
        <div class="row justify-content-end">
            <asp:Label ID="lbl_Total" runat="server" Text="" CssClass="h4"></asp:Label>
        </div>

        <br />
        <br />
        <div class="row justify-content-center">
            <asp:Button ID="btn_BackProductFormulation" class="btn btn-warning" runat="server" Text="Back to Product Formulation" OnClick="btn_BackProductFormulation_Click" />
            <asp:Button ID="btn_CheckOut" class="btn btn-info" runat="server" Text="Check out" OnClick="btn_CheckOut_Click" />
        </div>
            

    </div>

    
</asp:Content>
