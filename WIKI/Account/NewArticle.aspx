<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="NewArticle.aspx.cs" Inherits="WIKI.Account.NewArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <fieldset>
 <ol>
     <li>
    <asp:Label ID="Label1" runat="server" Text="Create New Article" Font-Bold="True"></asp:Label>
     </li>

     
   
        <li>
    <asp:Label ID="Label2" runat="server" Text="Title:"></asp:Label>
            </li>

            <li>
    <asp:TextBox ID="txtNaslov" runat="server" MaxLength="300" Width="590px"></asp:TextBox>
        </li>

<li>
 <asp:Label ID="Label3" runat="server" Text="Content:"></asp:Label>
      </li>

        <li>
<asp:TextBox ID="txtSadrzaj" runat="server" Height="119px" MaxLength="5000" TextMode="MultiLine" style="resize:none" Width="590px"></asp:TextBox>
        </li>
<li>
    <asp:Label ID="Label4" runat="server" Text="Category:"></asp:Label>
    <asp:DropDownList ID="DropDownCategory" runat="server" 
        DataTextField="NazivKategorije" DataValueField="Id" Height="34px" 
        onload="DropDownList1_Load" 
        onselectedindexchanged="DropDownCategory_SelectedIndexChanged" 
        Width="170px" oninit="DropDownCategory_Init">
    </asp:DropDownList>
    </li>
<li>
    <asp:Label ID="Label5" runat="server" Text="Tags:"></asp:Label>
    </li>
   <li>
    <asp:TextBox ID="txtKljucnaRijec1" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec2" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec3" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec4" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec5" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec6" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec7" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec8" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec9" runat="server" Width="108px"></asp:TextBox>
    <asp:TextBox ID="txtKljucnaRijec10" runat="server" Width="108px"></asp:TextBox>
   </li>   

<li>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" CssClass="btn-primary" />
  </li>

    </ol>

         </fieldset>
</asp:Content>
