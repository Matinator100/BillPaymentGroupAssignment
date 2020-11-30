<%@ Page Title ="Pay Money To Your Flow Account" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PaymentFlow.aspx.cs" Inherits="BillPaymentGroupAssignment.PaymentFlow" %>

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
        <p class ="h1">Pay to your Flow account</p>
        <h3 class ="lead">Here you can pay money from your JCB account to your Flow account</h3>
    </div>
    <asp:PlaceHolder runat="server" ID="PayStatus" Visible="false">
        <p>
            <asp:Literal runat="server" ID="StatusText" />
        </p>
    </asp:PlaceHolder>
    <div class="border-top border-bottom border-dark mb-5">
        <h3>Payment to Linked Flow account below (To change, link to a new account): </h3>
        <asp:PlaceHolder ID ="FlowAccInfoHolder" runat ="server">

        </asp:PlaceHolder>
    </div>

    <asp:PlaceHolder runat="server" ID="PayFlowForm" Visible="true">
        <div style="margin-top: 10px; margin-bottom: 10px;">
            <asp:Label runat="server" AssociatedControlID="Amount">Payment: </asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Amount"  />
            </div>
        </div>
        <div style="margin-bottom: 10px">
            <div>
                <asp:Button runat="server" OnClick="PayToFlow" Text="Pay to your Flow account" />
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
