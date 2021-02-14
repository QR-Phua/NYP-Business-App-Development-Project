<%@ Page Title="Quiz | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="QuizPage1.aspx.cs" Inherits="WebApp.QuizPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <div class="container">
        <div class="progress">
            <div class="progress-bar bg-info" role="progressbar" style="width: 20%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
    </div>
    <br />
    <br />

    <div class="container">
        <div class="row justify-content-center">

            <div class="col-8">
                <h3 id="Qn1">How is your skin like when you wake up?</h3>

            </div>


            <div class="col-4">
                <!-- Button trigger modal -->
                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#ModalCenter1">
                    How to find out your skin type
                </button>
            </div>

            <!-- Modal -->
            <div class="modal fade" id="ModalCenter1" tabindex="-1" role="dialog" aria-labelledby="ModalCenterTitle1" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="ModalLongTitle1">How to find out your skin type</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            If your skin feels dry after waking up, you probably have dry skin. You may have oily skin if your face feels greasy upon waking up. Combination skin refers to your T-Zone being oily while other parts of your face is dry. You have balanced skin if your face do not feel greasy or dry.
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row justify-content-center">
            <div class="container">


                <div class="col-8">
                    <asp:RadioButtonList ID="rbl_SkinType" runat="server" CssClass="auto-style1" >

                        <asp:ListItem Value="D" style="margin-bottom:30px">Dry</asp:ListItem>
                        <asp:ListItem Value="B" style="margin-bottom:30px">Balanced</asp:ListItem>
                        <asp:ListItem Value="O" style="margin-bottom:30px">Oily</asp:ListItem>
                        <asp:ListItem Value="C">Combination of Dry and Oily</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <br />
                <div class="col-4">
                    <asp:RequiredFieldValidator ID="rfv_SkinType" runat="server" ErrorMessage="Please select an option" ControlToValidate="rbl_SkinType" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-8">
                <h3 id="Qn2">Do you have sensitive skin?</h3>
            </div>

            <div class="col-4">
                <!-- Button trigger modal -->
                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#ModalCenter2">
                    Why are we asking this?
                </button>

                <!-- Modal -->
                <div class="modal fade" id="ModalCenter2" tabindex="-1" role="dialog" aria-labelledby="ModalCenterTitle2" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="ModalLongTitle2">Why are we asking this?</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                This question helps us find ingredients that will not irritate your skin and are suitable for your skin type.
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="container">
            <div class="col-8">
                <asp:RadioButtonList ID="rbl_Sensitivity" runat="server">
                    <asp:ListItem Value="N" style="margin-bottom:30px">No</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <div class="col-4">
                <asp:RequiredFieldValidator ID="rfv_Sensitivity" runat="server" ErrorMessage="Please select an option" ControlToValidate="rbl_Sensitivity" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            </div>
        </div>
    </div>
        <br />
    <br />
   
        <div class="container">
            <div class="row justify-content-center">
                <asp:Button Class="btn btn-primary" ID="btn_Submit" runat="server" Text="Next" OnClick="btn_Submit_Click" />
            </div>
        </div>

    </asp:Content>

