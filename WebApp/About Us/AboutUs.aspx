<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" Inherits="WebApp.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1415px;
        }
        .auto-style6 {
            width: 471px;
        }
        .auto-style7 {
            width: 472px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <table class="auto-style2">

        <tr>
            <td class="auto-style6">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/logo_transparent.png"/ Width="300px" />
            </td>
            <td class="auto-style7">
                <h3>Chadior Beauty</h3>
            </td>
            <td class="auto-style7">
                <ul>
                    <li>
                        Founded by a group of teenagers
                    </li>
                    <li>
                        Aim to make it easier for consumers when purchasing the products they need
                    </li>
                    <li>
                        Caters to all skin types of customers
                    </li>
                </ul>
            </td>
        </tr>

        <tr>
            <td class="auto-style6">
                <h3>
                    Easier. Simpler. Skincare Routines
                </h3>
            </td>
            <td class="auto-style7">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Screenshot 2021-02-17 005450.jpg" width="300px" />
            </td>
            <td class="auto-style7">
                Feeling tired after a long day out? Don't worry! Chadior Beauty has got what you want!
            </td>
        </tr>

        <tr>
            <td>
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Screenshot 2021-02-17 012334.jpg" Width="200px" />
            </td>
            <td class="auto-style7">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Screenshot 2021-02-17 012259.jpg" Width="200px" />
            </td>
            <td class="auto-style7">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Screenshot 2021-02-17 012207.jpg" Width="200px" />
            </td>
        </tr>

        <tr>
            <td>
                Step 1:
                <br />
                Customised Facial Cleanser
                <br />
                <ul>
                    <li>
                        Makeup/ non-makeup users
                    </li>
                    <li>
                        Gentle yet effective
                    </li>
                    <li>
                        Customisable
                    </li>
                </ul>
            </td>

            <td class="auto-style7">
                Step 2:
                <br />
                Customised Toner Serum
                <br />
                <ul>
                    <li>
                        Contains both toner & serum
                    </li>
                    <li>
                        High efficacy & fragrance-free
                    </li>
                    <li>
                        Customisable
                    </li>
                </ul>
            </td>

            <td class="auto-style7">
                Step 3:
                <br />
                Customised Moisturiser
                <br />
                <ul>
                    <li>
                        Maintain hydration
                    </li>
                    <li>
                        Comes in many different sizes
                    </li>
                    <li>
                        Customisable
                    </li>
                </ul>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style6">
                <ul>
                    <li>
                        Subscription Feature
                    </li>
                    <li>
                        Door-to-door delivery
                    </li>
                </ul>
            </td>
            <td class="auto-style7">
                You can choose the ingredients you want to add in your skincare product
            </td>
            <td class="auto-style7">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Screenshot 2021-02-17 010801.jpg" Width="300px" />
            </td>
        </tr>

    </table>

</asp:Content>