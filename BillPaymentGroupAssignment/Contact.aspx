<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BillPaymentGroupAssignment.Contact" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item">
        <a class="nav-link" href="Default.aspx">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Accounts.aspx">Accounts</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="About.aspx">About us</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content ID="ContactPageBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <p class ="h1">Contact Us</p>
        <h3 class ="lead">Here is our Contact Information </h3>
    </div>
    <div class="border-top border-bottom border-dark mb-5 pl-1">
        <div class ="text-center">
             <h3 class ="pt-2"></h3>
        </div>
    </div>

</asp:Content>
