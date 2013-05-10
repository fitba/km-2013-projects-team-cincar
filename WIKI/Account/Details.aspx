<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WIKI.Account.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

 <asp:Repeater ID="Repeater1" runat="server">

 <ItemTemplate>
    <div id="naslov" style="float:left; margin-right:20px; background-color:Gray; font-size:large; color:White; width:95% " >
         <%# Eval("Id")%>
         </div>
       <br />
         <div id="sadrzaj" style="float:left; margin-right:20px" >
         <%# Eval("Name")%>
         </div>
     <br />
     <br />
      Views:
          <%# Eval("Description")%>
   </ItemTemplate>
    </asp:Repeater>
</asp:Content>
