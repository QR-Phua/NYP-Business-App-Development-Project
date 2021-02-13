<%@ Page Title="Quiz | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="QuizPage2.aspx.cs" Inherits="WebApp.Quiz_Pages.QuizPage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <script>
        $(document).ready(function () {

            $('#lbl_Warning').change(function () {
                if ($(this).text() !== "Please select 2 Options") {
                    $('#lbl_Warning').css('color', 'red');
                }
            })
        });
    </script>

    <div class="container">
        <div class="progress">
            <div class="progress-bar bg-info" role="progressbar" style="width: 40%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
    </div>
    <br />
    <br />

    <div class="container">
        <div class="row justify-content-center">
            <h3 class="title">What are your main skin concerns?</h3>
        </div>
        <br />
        <div class="row justify-content-center">
            
            <asp:CheckBoxList ID="cb_Concerns" runat="server" OnSelectedIndexChanged="cb_Concerns_SelectedIndexChanged">
                <asp:ListItem Value="A" style="margin-bottom:30px">Acne</asp:ListItem>
                <asp:ListItem Value="R" style="margin-bottom:30px">Redness and Irritation</asp:ListItem>
                <asp:ListItem Value="D" style="margin-bottom:30px">Dullness and Age Spots</asp:ListItem>
                <asp:ListItem Value="B" style="margin-bottom:30px">Blemishes and Pigmentation</asp:ListItem>
                <asp:ListItem Value="Y" style="margin-bottom:30px">Dryness</asp:ListItem>
                <asp:ListItem Value="L">Blackheads and Whiteheads</asp:ListItem>
            </asp:CheckBoxList>
            
        </div>
    </div>
    <br />
    
    <div class="row justify-content-center">
        <asp:Label ID="lbl_Warning" runat="server" >Please select 2 Options</asp:Label>
    </div>

    <div class="container">
        <div class="row justify-content-center">
            
            <div class="col-6">
                <div class="row justify-content-center"><asp:Button Class="btn btn-danger" ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click"  /></div>
            </div>

            <div class="col-6">
                <div class="row justify-content-center"><asp:Button Class="btn btn-primary" ID="btn_Submit" runat="server" Text="Next" OnClick="btn_Submit_Click" /></div>
            </div>
        </div>
    </div>
</asp:Content>



