<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ReviewForm.aspx.cs" Inherits="WebApp.Review_Form.ReviewForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <br />
        <br />
        <div class="row justify-content-center">
            <h2>How would you rate this formulation?</h2>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col">
                <h5>Problem Areas targeted</h5>
                <br />
                <div class="row">
                    <asp:Label ID="lbl_Problem1" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_Problem2" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_Problem3" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="col">
                <h5>Ingredient Chosen</h5>
                <br />
                <div class="row">
                    <asp:Label ID="lbl_Ingredient1" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_Ingredient2" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_Ingredient3" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <br />
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <ajaxToolkit:SliderExtender EnableHandleAnimation="true" TooltipText="Move the slider to rate" ID="slideExtender1" runat="server"  TargetControlID="Slider1" BoundControlID="SliderValue" Length="500" />
        <div class="row justify-content-center">
            <h5>Please rate your satisfaction</h5>
        </div>
        <br />

        <div class="row justify-content-center">
            <asp:TextBox ID="Slider1" runat="server" />
        </div>

        <div class="row justify-content-center">
            <asp:Label ID="SliderValue" runat="server" Text=""></asp:Label>

        </div>

        <br />
        <br />


        <div class="row justify-content-center">
            <asp:Button Class="btn btn-info" ID="btn_Submit" runat="server" Text="Submit Review" OnClick="btn_Submit_Click" />
        </div>


    </div>
</asp:Content>
