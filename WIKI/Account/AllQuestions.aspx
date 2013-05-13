<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="AllQuestions.aspx.cs" Inherits="WIKI.Account.AllQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="well form-search">
           Try these searches: "RecSys", "Windows"
         <br />
         <br />
        <asp:TextBox ID="txtSearch" runat="server" class="span4 search-query" placeholder="Search..." />     
        <asp:Button ID="btnSearch" Text="Search" OnClick="btnSearch_Click" runat="server" class="btn" type="button" />
    </div>


      <div id="Search" class="well form-search">

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
             
               
                <td> <a href="QuestionDetails.aspx?QuestionId=<%# Eval("Id")%>"><%# Eval("Name")%></a></td>

            
              
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

    <div class="container">
      <div class="row">  
    <table class="table table-striped">
       <asp:Repeater ID="Repeater1" runat="server" >
  
            <ItemTemplate>
              <tr>
                    <th><h4> <a href="QuestionDetails.aspx?QuestionId=<%# Eval("QuestionId")%>"><%# Eval("QuestionTitle")%></a></h4></th>
               </tr>

                <tr>
                
                   <td> <h5> <%# Eval("QuestionBody")%></h5></td>
                </tr>
            </ItemTemplate>
   </asp:Repeater>

</table>

</div>

<div class="row">
    <asp:LinkButton ID="NewQuestion" runat="server" OnClick="NewQuestion_Click" CssClass="btn btn-primary">New Question</asp:LinkButton>
    </div>

    </div>
</asp:Content>
