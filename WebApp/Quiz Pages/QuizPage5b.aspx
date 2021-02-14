<%@ Page Title="Quiz | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="QuizPage5b.aspx.cs" Inherits="WebApp.Quiz_Pages.QuizPage5b" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script>

        $(document).ready(function () {

            $(function () {
                $('button[id="option"]').click(function (e) {
                    e.preventDefault();
                    $('#hide_text').show();
                });
            });
        });

    </script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />


    <div class="container">
        <div class="row justify-content-center">
            <h3>Which ingredient caused it?</h3>
        </div>
        <br />
        <div class="row justify-content-center">
            <asp:CheckBoxList ID="cb_AllerIngredients" runat="server">
                <asp:ListItem Value="Benzoyl Peroxide" style="margin-bottom: 30px">Benzoyl Peroxide</asp:ListItem>
                <asp:ListItem Value="Salicylic Acid" style="margin-bottom: 30px">Salicylic Acid</asp:ListItem>
                <asp:ListItem Value="Retinol">Retinol</asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </div>
    <br />
        <div class="container">
            <div class="row justify-content-center">
                <button id="option" type="reset" class="btn btn-primary">Others</button>
            </div>
            <br />
            <div class="row justify-content-center">
                <asp:Label ID="lbl_Load" runat="server" Text="Please click on the 'others' to see your entries" ForeColor="Red" Visible="False"></asp:Label>
            </div>

            </div>
            <br />
            <div class="row justify-content-center">
                <div id="hide_text" class="auto-style1" style="display: none;">
                    
                     <div class="row justify-content-center"><asp:Textbox ID="tb_Others" runat="server" Width="80%"></asp:Textbox></div>
                    
                    <br />
                     <div class="row justify-content-center"><label>Please enter each ingredient and end with a ",". Please do not leave a space after the comma</label></div>
                    </div>
                </div>
            
            <br />
            <div class="row justify-content-center">
                <span id="errorMsg"></span>
            </div>
            
        <br />
         <br />
        

   <div class="container">
        <div class="row justify-content-center">
            
            <div class="col-6">
                <div class="row justify-content-center"><asp:Button Class="btn btn-danger" ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click"  /></div>
            </div>

            <div class="col-6">
                <div class="row justify-content-center"><asp:Button Class="btn btn-primary" ID="btn_Submit" clientIDMode="Static" runat="server" Text="Next" OnClick="btn_Submit_Click" style="width: 59px" /></div>
            </div>
        </div>
    </div>

    
   
</asp:Content>


