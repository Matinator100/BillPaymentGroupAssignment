<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BillPaymentGroupAssignment._Default" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item active">
        <a class="nav-link" href="#">Home<span class="sr-only">(current)</span></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Accounts.aspx">Accounts</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="About.aspx">About us</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content ID="HomePageBody" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h3 class ="lead ">Welcome to...</h3>
        <p class ="h1 text-primary">JCB Banking's Online Platform</p>
        <h3 class ="lead">Here you can check information related to your JCB account! </h3>
    </div>

    <div class="row mt-5">
        <div class="col-md-4 text-center">
            <h2>Thank you for using our Online Platform</h2>
            <p>
                This online platform allows you to not only view your JCB account information, but also make Payments to your Flow or Sagicor accounts all from the comfort of your Home 
            </p>
            <div style ="text-align: center;">
                <asp:HyperLink ID="LoginBtn" cssClass="btn btn-primary " runat="server" NavigateUrl ="~/Account/Login.aspx">Login Here</asp:HyperLink>
            </div>
        </div>
        <div class="col-md-4 text-center">
            <h2>No more waiting in pesky lines!</h2>
            <p>
               Making payments to your Flow or Sagicor account is just a few simple clicks. Simple, easy and no hassle!
            </p>
            <div style ="text-align: center;">
                <asp:HyperLink ID="AccountBtn" cssClass="btn btn-primary" runat="server" NavigateUrl ="~/LinkFlowSagicor.aspx">Link an Account</asp:HyperLink>
            </div>
        </div>
        <div class="col-md-4 text-center">
            <h2>Still want to go in person?</h2>
            <p>
                We got you covered, JCB has several branches islandwide with friendly and curteous staff to help with all your banking needs
            </p>
            <div>
                <asp:HyperLink ID="LearnMoreBtn" cssClass="btn btn-primary" runat="server" NavigateUrl ="~/About.aspx">Learn More</asp:HyperLink>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
