<%@ Page Title ="Pay Money To Your Sagicor Account" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="PaymentSagicor.aspx.cs" Inherits="BillPaymentGroupAssignment.PaymentSagicor" %>

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
        <p class ="h1">Pay to your Sagicor Life account</p>
        <h3 class ="lead">Here you can pay money from your JCB account to your Sagicor Life account</h3>
    </div>
    <asp:PlaceHolder runat="server" ID="PayStatus" Visible="false">
        <p>
            <asp:Literal runat="server" ID="StatusText" />
        </p>
    </asp:PlaceHolder>
    <div class="border-top border-bottom border-dark mb-5">
        <h3>Payment to Linked Sagicor Life account below (To change, link to a new account): </h3>
        <asp:PlaceHolder ID ="SagicorAccInfoHolder" runat ="server">

        </asp:PlaceHolder>
    </div>

    <asp:PlaceHolder runat="server" ID="PaySagicorForm" Visible="true">
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <asp:Label runat="server" AssociatedControlID="Amount">Payment: </asp:Label>
            <div>
                <asp:RegularExpressionValidator cssClass="full-label" ID="PaymentRegularExpressionValidator" runat="server" ControlToValidate="Amount" ForeColor ="Red" ValidationExpression ="^[1-9]\d*(\.\d+)?$" ErrorMessage="Value entered is not a valid amount"></asp:RegularExpressionValidator>
                <asp:TextBox runat="server" ID="Amount"  />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <div>
                <asp:Button CssClass="btn btn-primary" runat="server" OnClick="PayToSagicor" Text="Pay to your Sagicor Life account" />
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
