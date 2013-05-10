<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="WIKI.Account.EditArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
       <asp:Label ID="Label2" runat="server" Text="Edit Master Title"></asp:Label>
       
        </div>
    <br />
            <div class="row">
            <asp:TextBox ID="txtNaslov" runat="server" Enabled="True" Width="600px"></asp:TextBox>
       
     </div>
   <br />    <div class="row">
            <asp:Label ID="Label4" runat="server" Text="Edit Master Content"></asp:Label>
      
       </div>
     <br />    <div class="row">
    <asp:TextBox ID="txtSadrzaj" runat="server" Enabled="true" Visible="true" Height="110px" style="resize:none" TextMode="MultiLine" Width="600px"></asp:TextBox>
            </div>
                
    <br />    <div class="row">
    <asp:Button ID="Button1" runat="server" Text="Update Changes" OnClick="Button1_Click" CssClass="btn-primary" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" CssClass="btn" />
        </div>
</div>
</asp:Content>
