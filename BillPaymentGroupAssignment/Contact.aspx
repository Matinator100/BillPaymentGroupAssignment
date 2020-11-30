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
             <h3 class ="pt-2"><span style="color: rgb(118, 118, 118); font-family: Roboto, Helvetica, sans-serif; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none; background-color: rgb(255, 255, 255)">&nbsp;</span><span class="bm_details_overlay" data-detailsoverlay="{&quot;centerLatitude&quot;:18.01822280883789,&quot;centerLongitude&quot;:-76.74407958984375,&quot;zoom&quot;:16,&quot;localDetailsState&quot;:{&quot;entityType&quot;:&quot;Satori&quot;,&quot;launchOverflowTaskOnTaskActivate&quot;:false,&quot;query&quot;:&quot;University of Technology, Jamaica&quot;,&quot;id&quot;:&quot;sid:17258169-7ea1-0770-cdf7-254cd1ef2eb3&quot;,&quot;disableComputingMapViewForLoadingOnly&quot;:true}}" style="color: rgb(118, 118, 118); font-family: Roboto, Helvetica, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline;"><a h="ID=SERP,5423.1" href="https://www.bing.com/maps?&amp;ty=18&amp;q=University%20of%20Technology%2c%20Jamaica&amp;satid=id.sid%3a17258169-7ea1-0770-cdf7-254cd1ef2eb3&amp;ppois=18.01822280883789_-76.74407958984375_University%20of%20Technology%2c%20Jamaica_~&amp;cp=18.018223~-76.74408&amp;v=2&amp;sV=1" style="color: rgb(102, 0, 153); text-decoration: none;">237 
                 Old Hope Road, Kingston 6, Kingston</a></span></h3>
             <p class ="pt-2">Tel: +1 (876) 659-3178</p>
             <p class ="pt-2">Email: info@jcb.com</p>
        </div>
    </div>

</asp:Content>
