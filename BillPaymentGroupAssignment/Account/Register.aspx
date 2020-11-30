<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BillPaymentGroupAssignment.Account.Register" %>

<asp:Content ID="NavBody" ContentPlaceHolderID="NavbarPlaceHolder" runat="server">
     <li class="nav-item active">
        <a class="nav-link" href="../Default.aspx">Home<span class="sr-only">(current)</span></a>
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
        <p class ="h1">Register</p>
    </div>
    <div>
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>  
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="UserName" />                
            </div>
        </div>
        <asp:RegularExpressionValidator ID="PasswordValidator" runat="server" ControlToValidate ="Password" ForeColor="Red" ErrorMessage="Password must be eight characters including at least one uppercase letter, one lowercase letter, one number and one special character:" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"></asp:RegularExpressionValidator>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
            </div>
        </div>
        <asp:RequiredFieldValidator ID="ConfirmPasswordValidator" ControlToValidate="ConfirmPassword" runat="server" ErrorMessage="Please confirm password"></asp:RequiredFieldValidator>
        <div style="margin-bottom:10px">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                
            </div>
        </div>
        <asp:CompareValidator ID="ComparePassValidator" Controltovalidate="Password" ControlToCompare ="ConfirmPassword" runat="server" ErrorMessage="Passwords do not match"></asp:CompareValidator>
        <div>
            <div>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
            </div>
        </div>
     </div>
</asp:Content>
