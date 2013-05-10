<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="AllQuestions.aspx.cs" Inherits="WIKI.Account.AllQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
