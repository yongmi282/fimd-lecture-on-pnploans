<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs" Inherits="PnpLoans.Web.CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">

        <asp:Literal runat="server" ID="LitHtml" />

        <div class="form-group">
            <label>
                Lastname</label>
            <asp:TextBox runat="server" ID="TxtLastname" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtLastname"
                ErrorMessage ="Lastname is required."
                ID ="RfvLastname" />
        </div>
        <div class="form-group">
            <label>
                Firstname</label>
            <asp:TextBox runat="server" ID="TxtFirstname" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtFirstname"
                ErrorMessage ="Firstname is required."
                ID ="RequiredFieldValidator1" />
        </div>
        <div class="form-group">
            <label>
                Middle Name</label>
            <asp:TextBox runat="server" ID="TxtMiddlename" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtMiddlename"
                ErrorMessage ="Middlename is required."
                ID ="RequiredFieldValidator2" />
        </div>
        <div class="form-group">
            <label>
                Username</label>
            <asp:TextBox runat="server" ID="TxtUsername" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtUsername"
                ErrorMessage ="Username is required."
                ID ="RequiredFieldValidator3" />
        </div>
        <div class="form-group">
            <label>
                Usertype</label>
            <asp:DropDownList runat="server" ID="DdlUserType" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="DdlUserType"
                ErrorMessage ="Please choose from the drop-down list."
                ID ="RequiredFieldValidator4" />
        </div>

        <div class="form-group">
            <label>
                Email</label>
            <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control"/>
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtEmail"
                ErrorMessage ="Email is required."
                ID ="RequiredFieldValidator5" />
        </div>
        <div class="form-group">
            <label>
                Password</label>
            <asp:TextBox runat="server" ID="TxtPassword" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtPassword"
                ErrorMessage ="Password is required."
                ID ="RequiredFieldValidator6" />
        </div>
        <div class="form-group">
            <label>
                Repeat Password</label>
            <asp:TextBox runat="server" ID="TxtRepeatPassword" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator ForeColor ="Red"
                runat="server" ControlToValidate ="TxtRepeatPassword"
                ErrorMessage ="Please retype your Password."
                ID ="RequiredFieldValidator7" />
            <asp:CompareValidator
                ControlToValidate="TxtRepeatPassword"
                ControlToCompare ="TxtPassword"
                Type ="String" ForeColor="Red"
                ErrorMessage="Passwords mismatch."
                runat="server" ID="CvPassword" />
        </div>
        <asp:Button ID="BtnCreate" CssClass="btn btn-primary" Text="Create" runat="server" OnClick="BtnCreate_Click"/>
    </div>
</asp:Content>
