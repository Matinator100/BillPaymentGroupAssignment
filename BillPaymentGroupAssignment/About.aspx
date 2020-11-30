<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BillPaymentGroupAssignment.About" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item">
        <a class="nav-link" href="Default.aspx">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Accounts.aspx">Accounts</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="About.aspx">About us</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content ID="AboutUsPageBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <p class ="h1">About Us</p>
        <h3 class ="lead">What is JCB Bank</h3>
    </div>
    <div class="border-top border-bottom border-dark mb-5 pl-1">
        <div class ="text-center">
             <h3 class ="pt-2"><span>We are an Online portal which supports a new partnership agreement between ATL Auto and NCB that will allow existing NCB customers to log on and apply for preapproved autoloan. We also allow users to link other accounts and make payments to utility companies which will provide more convenience.</span></h3>
        </div>
    </div>

</asp:Content>
