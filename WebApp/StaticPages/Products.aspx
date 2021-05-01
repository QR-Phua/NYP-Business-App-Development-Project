<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApp.StaticPages.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
        .jumbotron {
            background-image: linear-gradient(rgba(0, 0, 0, 0.4), rgba(0, 0, 0, 0.4)), url("/Images/Hero Img 1.jpg");
            background-size: cover;
        }

        p {
            font-size: 18px;
            text-align: justify;
        }

        
    </style>

    <br />
    <br />
    <div class="container">
        <div class="jumbotron jumbotron-fluid text-white text-center jumbotron-image shadow ">
            <div class="container">
                <h1 class="display-4">Our Products</h1>
                
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-4 justify-content-center"><h3>Cleanser</h3></div>

            </div>
            <br />
            <div class="row">
                <div class="col-4">
                    <asp:Image ID="img_Cleanser" runat="server" ImageUrl="~/Images/Cleanser.jpg" Width="220px" CssClass="justify-content-end" />
                </div>

                <div class="col-8">
                    <p>Makeup users rejoice! One of our cleanser variant contains our proprietary formulation in effectively removing makeup without damaging the skin.
                        This means you do not need to use an oil cleanser beforehand to melt the makeup away! Lets not get too science-y here. All you need to know is 
                        that you will save time and not neglect your skin with it! 
                    </p>
                    <br />
                    <p>Fret not if you do not use makeup, we got you too! We have a non-makeup variant of our cleanser just for you. This cleanser is extra gentle yet
                        it removes impurities from your face with ease. Sounds too good to be true? Thanks to our proprietary supercharged cleansing formulation, this is
                        a reality. You will never have to worry if your skin is clean!
                    </p>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-4 justify-content-center"><h3>Toner-Serum</h3></div>
            </div>
            <br />
            <div class="row">

                <div class="col-4">
                    <asp:Image ID="img_Toner" runat="server" ImageUrl="~/Images/Toner.jpg" Width="220px" />
                </div>

                <div class="col-8">
                    <p style="justify-content: end;">
                        2 for 1? We love to see it! Our Toner Serum combines the best of both Toner and Serum together into a highly effective product to treat all your concerns.
                        It soothes and hydrates while the active ingredients chosen by you work its magic on your skin. We offer 2 variants of it, the Moisture variant and the 
                        Hydro variant. The moisture variant delivers a glass of water to your skin, deeply hydrating it and reinforces its barrier against allergens. This is
                        targeted towards people with drier skin. The Hydro variant is more for people with oily skin. It balances your skin's sebum production and optimally 
                        hydrates it to reduce excess sebum production. Our Skin Quiz would help to determine the best variant for you! 
                    </p>
                </div>

            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-4 justify-content-center"><h3>Moisturiser</h3></div>
            </div>
            <br />
            <div class="row">

                <div class="col-4">
                    <asp:Image ID="img_Moisturiser" runat="server" ImageUrl="~/Images/Moisturiser.jpg" Width="220px" />
                </div>

                <div class="col-8">
                    <p>
                        The final step of any skincare routine, Moisturiser! Our moisturiser seals the skin with a proprietary formulation, allowing all the good stuff from the Toner-Serum
                        to be absorbed by the skin. Our formulation slowly releases the active ingredients in the moisturiser to allow the skin to optimally absorb all of it. You won't
                        feel this but you are sure to see the results! We offer both Cream and Gel option to target all skintypes. Cream variant would be suitable for Dry Skin due to its
                        more moisturising properties while Gel variant is suitable for Oily Skin due to its lighter texture. Both variants are sure to meet your needs and concerns! Prepare
                        for that massive skin glowup! Our Skin Quiz would help to determine the best variant for you! 

                        
                    </p>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="container">
            <div class="row justify-content-center">
                <p>Interested in buying? Take the Skin Quiz and customise your skincare products to target all of your skincare concerns! </p>
            </div>
            <br />
            <div class="row justify-content-center">
                <asp:Button ID="btn_TakeQuiz" class="btn btn-info"  runat="server" Text="Take the Skin Quiz" OnClick="btn_TakeQuiz_Click" />
            </div>
        </div>

    </div>
    <br />
    <
</asp:Content>
