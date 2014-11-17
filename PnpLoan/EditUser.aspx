<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PnpLoan.Web.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="col-md-6">

        <asp:Literal runat="server" ID="LiHtml"/>

        <div class="form-group">
            <label>
                Lastname</label>
            <asp:TextBox runat="server" ID="TxtLastname" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="TxtLastname"
                ErrorMessage="Lastname is Required." ID="RfvLastname"/>
        </div>
        <div class="form-group">
            <label>
                Firstname</label>
            <asp:TextBox runat="server" ID="TxtFirstname" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="TxtFirstname"
                ErrorMessage="Firstname is Required." ID="RfvFirstname"/>
        </div>
        <div class="form-group">
            <label>
                Middle Name</label>
            <asp:TextBox runat="server" ID="TxtMiddlename" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="TxtMiddlename"
                ErrorMessage="Middlename is Required." ID="RfvMiddlename"/>
        </div>
        <div class="form-group">
            <label>
                Username</label>
            <asp:TextBox runat="server" ID="TxtUsername" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="TxtUsername"
                ErrorMessage="Username is Required." ID="RfvUsername"/>
        </div>
        <div class="form-group">
            <label>
                Usertype</label>
            <asp:DropDownList CssClass="form-control" runat="server" ID="DdlUserType"/>
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="DdlUsertype"
                ErrorMessage="Usertype is Required." ID="RfvUserType"/>
        </div>
        <div class="form-group">
            <label>
                Email</label>
            <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" />
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="TxtEmail"
                ErrorMessage="Email is Required." ID="RfvEmail"/>

            <asp:RegularExpressionValidator ID="RevEmail"
                ControlToValidate="TxtEmail" ErrorMessage="Invalid Email Format." ForeColor="Red" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
        </div>
       
       
        <asp:Button ID="BtnUpdate" CssClass="btn btn-primary" Text="Update" runat="server"
            OnClick = "BtnUpdate_Click"/>
        <br/>
        <br/>
        <br/>
  
    </div>
</asp:Content>




