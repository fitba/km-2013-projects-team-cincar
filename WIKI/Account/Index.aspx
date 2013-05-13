<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WIKI.Account.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <link href="../Content/profile.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style4 { height: 636px; }
    </style>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
     <div class="well form-search">
           Try these searches: "ASP", "ASP.NET"
         <br />
         <br />
        <asp:TextBox ID="txtSearch" runat="server" class="span4 search-query" placeholder="Search..." />     
        <asp:Button ID="btnSearch" Text="Search" OnClick="btnSearch_Click" runat="server" class="btn" type="button" />
    </div>
     

    <br />


	  
      <div id="Search" class="auto-style4">
      <asp:ListView ID="lvSearchIndex" runat="server" DataKeyNames="Name">
        <LayoutTemplate>
 	        <table class="table table-striped">
		        <tr>
			      
			        <th>Title</th>
			        <th>Description</th>
                   			      
		        </tr>         
            <tr id="itemPlaceHolder" runat="server"></tr>
          </table>
        </LayoutTemplate>
        <ItemTemplate>
          <tr>
             
               
                <td> <a href="ArticleDetails.aspx?ArticleId=<%# Eval("Id")%>"><%# Eval("Name")%></a></td>

            
              
			    <td><%# Eval("Description")%></td>
			      
      
		      </tr>
        </ItemTemplate>
          


        <EmptyDataTemplate>
          <br/><b>No search index records found...</b><br/>
        </EmptyDataTemplate>
      </asp:ListView>

         </div>
    <br />
    <br />
    <br />
    

    <div class="container" id="TopNews">
        <div class="row">
            <div class="span5">

                <div class="accordion" id="myaccordion">
                    <div class="accordion-group">
                        <div class="accordion-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#myaccordion" href="#first">
                                <b>Most Viewed Articles</b>
                            </a>
                        </div>
                        <div id="first" class="accordion-body collapse in">
                            <div class="accordion-inner">

              <asp:Repeater ID="Repeater1" runat="server">
                              <ItemTemplate>
   
                     <br />
                     <br />

                     <a href="ArticleDetails.aspx?ArticleId=<%# Eval("ArticleId")%>"><%# Eval("Title")%></a>
         
     
                     &nbsp
     
    
                     <%# Eval("Views")%>
 
                      </ItemTemplate>
                        </asp:Repeater>



                            </div>

                        </div>





                    </div>


                    <div class="accordion-group">
                        <div class="accordion-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#myaccordion" href="#second">
                                <b>Top Rated Articles</b>
                            </a>
                        </div>
                        <div id="second" class="accordion-body collapse in">
                            <div class="accordion-inner">
                          <asp:Repeater ID="Repeater2" runat="server">
              <ItemTemplate>
              <br />
            <a href="ArticleDetails.aspx?ArticleId=<%# Eval("ArticleId")%>"><%# Eval("Title")%></a>
           &nbsp
                      
            Average Score:
            <%# Eval("Average")%>
            <br />
        </ItemTemplate>


    </asp:Repeater>




                            </div>

                        </div>





                    </div>

                    <div class="accordion-group">
                        <div class="accordion-heading">
                            <a class="accordion-toggle" data-toggle="collapse" data-parent="#myaccordion" href="#tri">
                                <b>Most Recent Articles</b>
                            </a>
                        </div>
                        <div id="tri" class="accordion-body collapse in">
                            <div class="accordion-inner">

                            <asp:Repeater ID="Repeater3" runat="server">

         <ItemTemplate>
            <br />
            <a href="ArticleDetails.aspx?ArticleId=<%# Eval("ArticleId")%>"><%# Eval("Title")%></a>
            &nbsp
                      
            Date:
            <%# Eval("CreateDate")%>
            <br />
        </ItemTemplate>



    </asp:Repeater>


                            </div>

                        </div>


                    </div>


                </div>

            </div>

        </div>

    </div>
                  
 

</asp:Content>


