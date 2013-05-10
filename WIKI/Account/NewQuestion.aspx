<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="WIKI.Account.NewQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
     <ol>
         <li>
    <asp:Label ID="Label1" runat="server" Text="Ask a question" Font-Bold="True"></asp:Label>
</li>
         <li>
    <asp:Label ID="Label2" runat="server" Text="Title:"></asp:Label>
             </li>

         <li>
    <asp:TextBox ID="txtTitle" runat="server" MaxLength="300" Width="590px"></asp:TextBox>
         </li>

         <li>
 <asp:Label ID="Label3" runat="server" Text="Question:"></asp:Label>
             </li>

<li>
<asp:TextBox ID="txtBody" runat="server" Height="119px" MaxLength="5000" TextMode="MultiLine" style="resize:none" Width="590px"></asp:TextBox>
  </li>      


         <li>
    <asp:Label ID="Label5" runat="server" Text="InsertTags:"></asp:Label>
         </li>

         <li>
    <asp:TextBox ID="txtTag1" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag2" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag3" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag4" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag5" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag6" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag7" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag8" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag9" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtTag10" runat="server" Width="108px"></asp:TextBox>
</li>

         <li>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Send" CssClass="btn-primary" />
</li>

</ol>
        </fieldset>
</asp:Content>
