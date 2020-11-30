<%@ Page Title ="Accounts" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Accounts.aspx.cs" Inherits="BillPaymentGroupAssignment.Accounts" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item">
        <a class="nav-link" href="Default.aspx">Home</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Accounts.aspx">Accounts</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="About.aspx">About us</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content ID="AccountsPageBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <p class ="h1">Accounts</p>
        <h3 class ="lead">Here you can See your account information</h3>
    </div>
    <div class="border-top border-bottom border-dark mb-5 pl-1">
        <h3 class ="pt-2">Your JCB account Information:</h3>
        <div>
            <asp:Label ID="AccNum" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="AccName" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="AccBalance" runat="server"></asp:Label>
        </div>
        <div class ="mt-1 pb-2">
            <asp:HyperLink ID="LinkAccountsBtn" cssClass="btn btn-primary" runat="server" NavigateUrl ="~/LinkFlowSagicor.aspx">Link an Account/ Pay a bill?</asp:HyperLink>
        </div>
    </div>

</asp:Content>
