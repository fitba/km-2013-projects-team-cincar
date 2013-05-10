<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WIKI.Account.Profile1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="form-horizontal well"> 
           
    <asp:Label ID="Label1" runat="server" Text="Choose Category" ForeColor="Black" Font-Size="Medium" Font-Bold="True"></asp:Label>
             
    <br />

    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
                <br />
    
                  
                  <a href="CategoryDetails.aspx?CategoryId=<%# Eval("CategoryId")%>"><%# Eval("Title")%></a>
                        
        
                <br />
            
  </ItemTemplate>

    </asp:Repeater>

    <br />

    <asp:Button ID="btnNewArticle" runat="server" Text="Set New Article" OnClick="btnNewArticle_Click" CssClass="btn btn-primary" />


 <br />
</div>
</asp:Content>
