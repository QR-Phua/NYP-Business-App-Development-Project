<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="QuizPage5a.aspx.cs" Inherits="WebApp.Quiz_Pages.QuizPage5a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
    </div>
    <br />
    <br />

    <div class="container">
        <div class="row justify-content-center">
            <h3>Do you know any skincare ingredients that give you adverse effects?</h3>
        </div>
        <br />
        <div class="row justify-content-center">

            <asp:RadioButtonList ID="rbl_Allergic" runat="server" CssClass="auto-style1">

                <asp:ListItem Value="Yes" style="margin-right: 30px">Yes</asp:ListItem>
                <asp:ListItem Value="No">No</asp:ListItem>

            </asp:RadioButtonList>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:Label ID="lbl_Warning" runat="server" Text=""></asp:Label>
        </div>

    </div>
        <br />

    <div class="container">
        <div class="row justify-content-center">
            
            <div class="col-6">
                <div class="row justify-content-center">
                <asp:Button Class="btn btn-danger" ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click"  />
                </div>
            </div>

            <div class="col-6">
                <div class="row justify-content-center">
                <asp:Button Class="btn btn-primary" ID="btn_Submit" runat="server" Text="Next" OnClick="btn_Submit_Click" style="width: 59px" />
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
