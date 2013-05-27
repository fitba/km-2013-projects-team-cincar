<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="WIKI.Account.ArticleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 { height: 37px; }
    </style>
    <link href="../Content/profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      






    <div class="container-fluid">
    <div class="span7">
    <asp:Repeater ID="Repeater1" runat="server" >
   <ItemTemplate>

    <div class="row">
       <h4> <%# Eval("Title")%></h4> 
        </div>

       <br />

      <div class="row">
       <h5> <%# Eval("Body")%></h5> 
       </div>
    
   </ItemTemplate>
   </asp:Repeater>
       
    
    
              
                <br />
                <br />
<div class="row">
 <asp:Label ID="Label6" runat="server" Text="Created By:"></asp:Label>
&nbsp;<asp:Label ID="lblAutor" runat="server" Text="Label"></asp:Label>
    </div>

    <br />
        <div class="row">
    <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
            </div>
    <br />
          <div class="row">
    <asp:Label ID="Views" runat="server" Text="Views"></asp:Label>
    <asp:Label ID="lblViews" runat="server" Text=""></asp:Label>
              </div>
    	  <br />
          
     <div class="row">
    <asp:Label ID="Label9" runat="server" Text="Tags: "></asp:Label>
    <asp:Label ID="lblTags" runat="server"></asp:Label>
         </div>
   
    <br />
<div class="row">
      <asp:Label ID="Label4" runat="server" Text="Grade: "></asp:Label>
                <asp:Label ID="lblBrojOcjena" runat="server" Text="-"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=" Times   "></asp:Label>
                <asp:Label ID="Label3" runat="server" 
                    Text="Average Score: "></asp:Label>
                <asp:Label ID="lblOcjena" runat="server" Text="Not Grade"></asp:Label>
    </div>
    <br />
   <div class="row">
     <div class="form-inline">
                <asp:DropDownList ID="DropDownListVoteArticle" runat="server" 
                    Width="64px">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem Selected="True">5</asp:ListItem>
                </asp:DropDownList>
         &nbsp
          <asp:Button ID="btnVoteArticle" runat="server" onclick="Button1_Click" Text="Rate Article" class="btn btn-small"/>

          </div>
       </div>
    <br />
    <br />
         <div class="row">
              <asp:LinkButton ID="btnEditArticle" runat="server" onclick="btnEditArticle_Click" class="btn btn-primary">Edit Article</asp:LinkButton>
             </div>
        </div>
         </div>
    <br />

    <div id="Recommend">
    <div class="container">

        <div class="row">

             <div class="span4">
                                     <h5>Wikipedia Recommendation</h5>
                            
                          
           
                              
                                                <asp:DataList ID="wikiList" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                         <div class="row">
                                                        
                                                            <a href='<%# Eval("Url") %>' target="_blank">
                                                                
                                                                <%# Eval("Name") %>
                                                            </a>
                                                     </div>
                                                    </ItemTemplate>
                                                </asp:DataList>

                                  </div>
                                </div>
     </div>


                          </div>               
                           
                     
      

  


</asp:Content>
