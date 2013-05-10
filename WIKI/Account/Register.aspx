<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WIKI.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 { width: 622px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
    

     <div id="Register" class="modal fade hide" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
       <div class="modal-header">
           <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h3>Register Form</h3>
   
   </div>
<div class="modal-body">
                                <asp:Label ID="label5" runat="server" AssociatedControlID="Firstname">Firstname</asp:Label>
                                <asp:TextBox runat="server" ID="Firstname" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Firstname"
                                    CssClass="field-validation-error" ErrorMessage="The firstname field is required." />
                            
                                <asp:Label ID="label6" runat="server" AssociatedControlID="Lastname">Lastname</asp:Label>
                                <asp:TextBox runat="server" ID="Lastname" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Lastname"
                                    CssClass="field-validation-error" ErrorMessage="The Lastname field is required." />
                          
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="Username">Username</asp:Label>
                                <asp:TextBox runat="server" ID="Username" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Username"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                           
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                           
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                          
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                          
                      

                       </div>

          <div class="modal-footer"> 
                        <asp:Button ID="btnRegister" runat="server" CommandName="MoveNext" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-success" />
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                       </div>

    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
   </div>


</asp:Content>
