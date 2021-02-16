<%@ Page Title="Home | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<script>
		$(document).ready(function () {

			$(function () {
				$("#carouselExampleIndicators").carousel();
				
				$("#carouselExampleIndicators").on('slide.bs.carousel', function (e) {
					var slide = $('.carousel-item.active img').attr('src');
					var direction = e.direction;
					if (slide === "Images/Hero Img 1.jpg") {
						if (direction === "left") {
							$('.nav-link').css("color", "white");
							$('.navbar-brand').css("color", "white");
                            $('.carousel-caption h5').css("color", "white");
                            $('.carousel-caption p').css("color", "white");
						}
						else {
                            $('.nav-link').css("color", "black");
							$('.navbar-brand').css("color", "black");
                            $('.carousel-caption h5').css("color", "white");
                            $('.carousel-caption p').css("color", "white");
                        }
					}
					else if (slide === "Images/Hero Pic 2.jpg") {
						if (direction === "left") {
							$('.nav-link').css("color", "black");
							$('.navbar-brand').css("color", "black");
                            $('.carousel-caption h5').css("color", "white");
                            $('.carousel-caption p').css("color", "white");
						}
						else {
                            $('.nav-link').css("color", "black");
							$('.navbar-brand').css("color", "black");
                            $('.carousel-caption h5').css("color", "#59564e");
                            $('.carousel-caption p').css("color", "#59564e");
                        }
						
					}
					else if (slide === "Images/Hero Pic 3.jpg") {
                        if (direction === "left") {
                            $('.nav-link').css("color", "black");
							$('.navbar-brand').css("color", "black");
                            $('.carousel-caption h5').css("color", "#59564e");
                            $('.carousel-caption p').css("color", "#59564e");
                        }
                        else {
                            $('.nav-link').css("color", "white");
							$('.navbar-brand').css("color", "white");
                            $('.carousel-caption h5').css("color", "white");
                            $('.carousel-caption p').css("color", "white");
                        }
					};
				});
			});

		});
    </script>

	<link href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.2/animate.min.css" rel="stylesheet">
    <link rel="stylesheet" href="StyleSheets/Home.css" type="text/css"/>

	<div class="carousel slide" data-ride="carousel" id="carouselExampleIndicators">
		<ol class="carousel-indicators">
			<li class="active" data-slide-to="0" data-target="#carouselExampleIndicators"></li>
			<li data-slide-to="1" data-target="#carouselExampleIndicators"></li>
			<li data-slide-to="2" data-target="#carouselExampleIndicators"></li>
		</ol>
		<div class="carousel-inner">
			<div class="carousel-item active">
				<img alt="First slide" class="d-block w-100 slideImg" src="Images/Hero Img 1.jpg"">
				<div class="carousel-caption d-none d-md-block">
					<h5 class="animated slideInDown" style="animation-delay: 1s">Discover our different skincare products</h5>
					<p class="animated fadeInUp" style="animation-delay: 2s">Create your personalised skincare products today</p>
					<p class="animated zoomIn" style="animation-delay: 3s"><a href="#">Learn More</a></p>
				</div>
			</div>
			<div class="carousel-item">
				<img alt="Second slide" class="d-block w-100 slideImg" src="Images/Hero Pic 2.jpg">
				<div class="carousel-caption d-none d-md-block">
					<h5 class="animated zoomIn" style="animation-delay: 1s">Find out what works best for your skin</h5>
					<p class="animated fadeInLeft" style="animation-delay: 2s">Create your personalised skincare products today</p>
					<p class="animated zoomIn" style="animation-delay: 3s"><a href="<%= ResolveUrl("~/Quiz Pages/QuizPage1.aspx") %>">More Info</a></p>
				</div>
			</div>
			<div class="carousel-item">
				<img alt="Third slide" class="d-block w-100 slideImg" src="Images/Hero Pic 3.jpg">
				<div class="carousel-caption d-none d-md-block">
					<h5 class="animated zoomIn" style="animation-delay: 1s">Only clean ingredients used</h5>
					<p class="animated fadeInRight" style="animation-delay: 2s">Find out how we source for our ingredients</p>
					<p class="animated zoomIn" style="animation-delay: 3s"><a href="#">Learn More</a></p>
				</div>
			</div>
		</div><a class="carousel-control-prev" data-slide="prev" href="#carouselExampleIndicators" role="button"><span aria-hidden="true" class="carousel-control-prev-icon"></span> <span class="sr-only">Previous</span></a> <a class="carousel-control-next" data-slide="next" href="#carouselExampleIndicators" role="button"><span aria-hidden="true" class="carousel-control-next-icon"></span> <span class="sr-only">Next</span></a>
	</div>

</asp:Content>
