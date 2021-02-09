<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="QuizPage4.aspx.cs" Inherits="WebApp.Quiz_Pages.QuizPage4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="progress">
            <div class="progress-bar bg-info" role="progressbar" style="width: 80%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
    </div>
    <br />
    <br />

    <div class="container">
        <div class="row justify-content-center">
            <h3>How many cups of water do you drink per day?</h3>
        </div>
        <div class="row justify-content-center">
            
                <div class="col-8">
                    <asp:RadioButtonList ID="rbl_WaterCon" runat="server" CssClass="auto-style1" >

                        <asp:ListItem Value="S">Less than 5 cups</asp:ListItem>
                        <asp:ListItem Value="M">5 to 7 cups</asp:ListItem>
                        <asp:ListItem Value="L">8 to 10 cups</asp:ListItem>
                        <asp:ListItem Value="X">More than 1o cups </asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-4">
                    <asp:Label ID="lbl_Warning" runat="server" Text=""></asp:Label>
                </div>
        </div>
        <br />
        <br />
        <div class="container">
        <div class="row justify-content-center">
            
            <div class="col-2">
                <asp:Button Class="btn btn-danger" ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click"  />
            </div>

            <div class="col-2">
                <asp:Button Class="btn btn-primary" ID="btn_Submit" runat="server" Text="Next" OnClick="btn_Submit_Click" />
            </div>
        </div>
    </div>
    </div>

</asp:Content>
