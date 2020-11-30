<%@ Page Title="Link a Sagicor Life Account" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SagicorInfoLink.aspx.cs" Inherits="BillPaymentGroupAssignment.SagicorInfoLink" %>

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
    <li class="nav-item">
        <a class="nav-link" href="Contact.aspx">Contact us</a>
    </li>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <p class ="h1">Link Your Sagicor Acount</p>
        <h3 class ="lead">Here you can enter your Sagicor account information for linking</h3>
    </div>
    <asp:PlaceHolder runat="server" ID="LinkStatus" Visible="false">
        <p>
            <asp:Literal runat="server" ID="StatusText" />
        </p>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="LinkFlowForm" Visible="true">
        <div style="margin-bottom: 10px">
            <asp:RegularExpressionValidator ID="AccNumValidator" cssClass="full-label-2" runat="server" ControlToValidate="AccountNumber" ForeColor ="Red" ValidationExpression ="^\d+$" ErrorMessage="Account number cannot contain letters or other characters"></asp:RegularExpressionValidator>
            <asp:Label runat="server" AssociatedControlID="AccountNumber">Account Number:</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="AccountNumber" />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="AccountEmail">Email associated with account</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="AccountEmail"/>
            </div>
        </div>
         <div style="margin-bottom: 10px">
            <asp:Label runat="server" AssociatedControlID="AccountPhoneNum">Phone Number associated with account</asp:Label>
            <div>
                <asp:RegularExpressionValidator ID="PhoneNumRegularExpressionValidator" cssClass="full-label-2" runat="server" ControlToValidate="AccountPhoneNum" ForeColor ="Red" ValidationExpression ="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$" ErrorMessage="Please enter a valid phone number (10 digits)"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="AccountPhoneNum"/>
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <div>
                <asp:Button CssClass="btn btn-primary" runat="server" OnClick="LinkAccount" Text="Link Sagicor Account" />
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
