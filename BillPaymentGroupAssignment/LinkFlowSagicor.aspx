<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LinkFlowSagicor.aspx.cs" Inherits="BillPaymentGroupAssignment.LinkFlowSagicor" %>

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

<asp:Content ID="AccountsPageBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <p class ="h1">Accounts</p>
        <h3 class ="lead">Here you can link your FLOW/SAGICOR account to you JCB account</h3>
    </div>
    <div class="border-top border-bottom border-dark mb-5">
        <h3>Flow</h3>
        <asp:PlaceHolder ID ="FlowAccInfoHolder" runat ="server">

        </asp:PlaceHolder>
    </div>
    <div class="border-top border-bottom border-dark mt-5">
        <h3>Sagicor</h3>
        <asp:PlaceHolder ID ="SagicorAccInfoHolder" runat ="server">

        </asp:PlaceHolder>
    </div>

</asp:Content>
