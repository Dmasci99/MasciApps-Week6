<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="MasciApps_Week6.UserControls.Header" %>
<%--
/**
* Author : Daniel Masci - 200299037
* Class : Enterprise Computing
* Semester : 4
* Professor : Tom Tsiliopolous
* Purpose : Assignment 1 - ASP.NET Portfolio
* Website Name : DanMasci.azurewebsites.net
* 
* The Following control is used as my Header that is called into the Site.Master
* and Interior.Master. It is used as a consistent menu across the whole site.
*/
--%>

<header class="header">
	<div class="container">
        <!-- Mobile Menu -->
        <span id="moby-button"><i class="fa fa-bars"></i></span>
        <div class="clear-float"></div><!-- clear-float -->

        <!-- Main Menu -->
        <nav id="header-nav">
	        <ul class="menu">
                <li id="home"><a href="~/Default.aspx"><i class="fa fa-lg fa-home"></i> Home</a></li>

                <asp:PlaceHolder runat="server" ID="PublicPlaceholder">
                    <li><a href="~/Login.aspx" runat="server" id="login"><i class="fa fa-lg fa-sign-in"></i> Login</a></li>
                    <li><a href="~/Register.aspx" runat="server" id="register"><i class="fa fa-lg fa-user-plus"></i> Register</a></li>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="PrivatePlaceholder">
                    <li><a href="~/Logout.aspx" runat="server" id="logout"><i class="fa fa-lg fa-sign-out"></i> Logout</a></li>
                    <li><a href="~/MainMenu.aspx" runat="server" id="mainMenu"><i class="fa fa-lg fa-map-signs"></i> Main Menu</a></li>
                    <li><a href="~/Students.aspx" runat="server" id="students"><i class="fa fa-lg fa-graduation-cap"></i> Students</a></li>
                    <li><a href="~/Courses.aspx" runat="server" id="courses"><i class="fa fa-lg fa-book"></i> Courses</a></li>
                    <li><a href="~/Departments.aspx" runat="server" id="departments"><i class="fa fa-lg fa-puzzle-piece"></i> Departments</a></li>
                </asp:PlaceHolder>

                <li><a href="~/Contact.aspx" runat="server" id="contact"><i class="fa fa-lg fa-phone"></i> Contact</a></li>
		        <div class="clear-float"></div><!--clear-float-->				
	        </ul>
        </nav><!--.header-nav-->

        <div class="clear-float"></div><!--clear-float-->
    </div>
</header>