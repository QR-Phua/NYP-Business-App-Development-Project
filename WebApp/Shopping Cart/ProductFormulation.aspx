<%@ Page Title="Products | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ProductFormulation.aspx.cs" Inherits="WebApp.Shopping_Cart.ProductFormulation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        h4{
            text-align: center;
        }

        .info{
            text-align: center;
        }

        #btn_Retake #btn_Reselect {
            align-content:center;
        }
        
    </style>

    <br />
    
    <div class="container">
        <div class="row justify-content-center">
            <div>
                <h3>Product Formulation</h3>
            </div>
        </div>
        <br />
        <br />

        <div class="row justify-content-center">
            <div class="col-6">
                <h4>Problem Areas</h4>
                <br />
                <div class="row justify-content-center"><asp:Label ID="lbl_Concern1" runat="server" Text=""></asp:Label></div>
                <div class="row justify-content-center"><asp:Label ID="lbl_Concern2" runat="server" Text=""></asp:Label></div>
                <br />
                <br />
                <div class="row justify-content-center"><asp:Button ID="btn_Retake" class="btn btn-danger" runat="server" Text="Retake the Skin Quiz" OnClick="btn_Retake_Click" /></div>
            </div>

            <div class="col-6">
                <h4>Ingredient Chosen</h4>
                <br />
                <div class="row justify-content-center"><asp:Label ID="lbl_Ingredient1" runat="server" Text=""></asp:Label></div>
                <div class="row justify-content-center"><asp:Label ID="lbl_Ingredient2" runat="server" Text=""></asp:Label></div>
                <div class="row justify-content-center"><asp:Label ID="lbl_Ingredient3" runat="server" Text=""></asp:Label></div>
                <br />
                <div class="row justify-content-center"><asp:Button ID="btn_Reselect" class="btn btn-warning " runat="server" Text="Return to ingredient selection" OnClick="btn_Reselect_Click" /></div>
            </div>
        </div>

        <br />
        <br />
        <h4>Ingredient Combination Recommendation</h4>
        <hr />
        
        <div class="row justify-content-center">
            <asp:Label ID="lbl_Recommended" runat="server" Width="80%" style="text-align: justify"></asp:Label>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:Button ID="btn_TakeRecommended" class="btn btn-info" Width="80%" runat="server" Text="Take the recommended ingredients" OnClick="btn_TakeRecommended_Click"  />
        </div>
        <hr />

        <br />
        <br />
        <div class="row justify-content-center">
            <div class="col-4">
                <div class="row justify-content-center"><asp:Image ID="img_Cleanser" runat="server" ImageUrl="~/Images/Cleanser.jpg" Width="200px" /></div>
            </div>

            <div class="col-4">
                <div class="row justify-content-center"><asp:Image ID="img_Toner" runat="server" Width="200px" ImageUrl="~/Images/Toner.jpg" /></div>
            </div>

            <div class="col-4">
                <div class="row justify-content-center"><asp:Image ID="img_Moisturiser" runat="server" ImageUrl="~/Images/Moisturiser.jpg" Width="200px" /></div>
            </div>
        </div>

        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">
                    <div class="col-4">
                        
                        
                        <div class="row justify-content-center"><h5>Cleanser</h5></div>
                        <div class="row justify-content-center"><h5>$19</h5></div>
                        <div class="row justify-content-center">
                            <h6>Select your quantity</h6>
                        </div>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row justify-content-center">
                                    <asp:DropDownList ID="ddl_Cleanser" runat="server">
                                        <asp:ListItem Value="0">Select Quantity</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <br />
                                <br />
                                <br />
                                <br />

                                <div class="row justify-content-center">
                                    <asp:Button ID="btn_AddCleanser" runat="server" Text="Add to Cart" OnClick="btn_AddCleanser_Click" />
                                    <br />
                                    <br />
                                </div>

                                <div class="row justify-content-center">
                                    <asp:Label ID="lbl_Cleanser" runat="server" Text=""></asp:Label>
                                </div>

                            </ContentTemplate>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btn_AddCleanser" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-4">
                        
                        <div class="row justify-content-center"><h5>Toner-Serum</h5></div>
                        <div class="row justify-content-center"><h5>$29</h5></div>
                        <div class="row justify-content-center">
                                <h6>Select your quantity</h6>
                        </div>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row justify-content-center">
                                        <asp:DropDownList ID="ddl_Toner" runat="server">
                                            <asp:ListItem Value="0">Select Quantity</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <br />
                                    <br />
                                    <br />
                                    <br />

                                    <div class="row justify-content-center">
                                        <asp:Button ID="btn_AddToner" runat="server" Text="Add to Cart" OnClick="btn_AddToner_Click" />
                                        <br />
                                        <br />
                                    </div>

                                    <div class="row justify-content-center">
                                        <asp:Label ID="lbl_Toner" runat="server" Text=""></asp:Label>
                                    </div>

                            </ContentTemplate>

                            <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btn_AddToner" EventName="Click" />
                            </Triggers>

                        </asp:UpdatePanel>

                    </div>

                    <div class="col-4">
                        
                        <div class="row justify-content-center"><h5>Moisturiser</h5></div>
                        <div class="row justify-content-center"><h5>$29</h5></div>
                            <div class="row justify-content-center">
                                <h6>Select your quantity</h6>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                
                                    <div class="row justify-content-center">
                                        <asp:DropDownList ID="ddl_Moisturiser" runat="server">
                                            <asp:ListItem Value="0">Select Quantity</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <br />
                                    <br />
                                    <br />
                                    <br />

                                    <div class="row justify-content-center">
                                        <asp:Button ID="btn_AddMoisturiser" runat="server" Text="Add to Cart" OnClick="btn_AddMoisturiser_Click" />
                                        <br />
                                        <br />
                                    </div>
                                    
                                    <div class="row justify-content-center">
                                        <asp:Label ID="lbl_Moisturiser" runat="server" Text=""></asp:Label>
                                    </div>

                                </ContentTemplate>

                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btn_AddMoisturiser" EventName="Click" />
                                </Triggers>

                            </asp:UpdatePanel>

                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="row justify-content-center">
                    <h5>Make this into a regular subscription?</h5>
                </div>
                    <br />
                    
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="row justify-content-center">
                                <asp:DropDownList ID="ddl_Subscription" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Subscription_SelectedIndexChanged" >
                                    <asp:ListItem Value="-1">Please select your option here</asp:ListItem>
                                    <asp:ListItem Value="0">No thanks!</asp:ListItem>
                                    <asp:ListItem Value="1">Yes please! 1 Month </asp:ListItem>
                                    <asp:ListItem Value="3">Yes please! 3 Month</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <br />
                            <br />
                            
                            <div class="row justify-content-center">
                                <asp:Label ID="lbl_Subscription" runat="server" Text=""></asp:Label>
                            </div>
                            
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddl_Subscription" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                
                
                <div class="container">
                    <div class="row justify-content-center">
                        <asp:Label ID="lbl_Redirect" runat="server" Text=""></asp:Label>
                    </div>
                        <br />
                        <br />
                    
                    <div class="row justify-content-center">
                        <asp:Button Class="btn btn-primary" ID="btn_Submit" runat="server" Text="Proceed to Shopping Cart" OnClick="btn_Submit_Click"  />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
</asp:Content>
