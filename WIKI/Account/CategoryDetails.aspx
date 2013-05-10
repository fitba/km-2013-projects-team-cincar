<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="WIKI.Account.CategoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 { width: 446px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
  


    <table class="table table-striped">
        <tr>
        <th class="span4">
         <asp:Label ID="Label1" runat="server" Text="Article From Category: " Font-Bold="True"></asp:Label>
            </th>
        
     <th class="span3"><asp:Label ID="lblKategorija" runat="server" Text="-" Font-Bold="True"></asp:Label></th>
            <th>

            </th>
            </tr>
        

    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
              
    <tr> 
                      
                <td> <a href="ArticleDetails.aspx?ArticleId=<%# Eval("ArticleId")%>"><%# Eval("Title")%></a></td> 
                    
                <td>   Created By:
                    <%#Eval("Username")%>
                </td>
                     
                   <td>   Date:
                    <%# Eval("CreateDate")%>
                </td> 
                           
        </tr>
              
           
 </ItemTemplate>
        
    </asp:Repeater>
     
    </table>


</asp:Content>
