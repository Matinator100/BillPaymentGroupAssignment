<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BillPaymentGroupAssignment.Account.Login" Async="true" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item">
        <a class="nav-link" href="../Default.aspx">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="../Accounts.aspx">Accounts</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="../About.aspx">About us</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="../Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <p class ="h1">Login</p>
        <h3 class ="lead">Here you can login to your JCB account here</h3>
    </div>
    <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
        <p>
           <span class ="red-text"><asp:Literal runat="server" ID="StatusText" /></span> 
        </p>
        </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="LoginForm" Visible="true">
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="UserName" />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <div>
                <asp:Button runat="server" OnClick="SignIn" Text="Log in" />
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
