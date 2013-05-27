<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Profile.Master" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="WIKI.Account.QuestionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/profile.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
<div class="span7">
<asp:Repeater ID="Repeater1" runat="server">

 <ItemTemplate>
   <div class="row">
         <h4><%# Eval("QuestionTitle")%></h4>
         </div>

       <br />
          <div class="row">
        <h5> <%# Eval("QuestionBody")%></h5>
         </div>
    
     <br />
     <div class="row">
      Views:
          <h6><%# Eval("NumOfViews")%></h6>
          </div>
   </ItemTemplate>
    </asp:Repeater>

  
        <br />   
        <div class="row">
        <asp:Label ID="Label6" runat="server" Text="Created By:"></asp:Label>
    &nbsp;
        <asp:Label ID="lblAutor" runat="server" Text="Label"></asp:Label>

            </div>

    <br />
        <div class="row">
    <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
              </div>
    	
          <br />
    <div class="row">
    <asp:Label ID="Label9" runat="server" Text="Tags: "></asp:Label>
    <asp:Label ID="lblKljucneRijeci" runat="server"></asp:Label>

        </div>
    <br />
         <div class="row">
      <asp:Label ID="Label4" runat="server" Text="Vote: "></asp:Label>
                <asp:Label ID="lblBrojOcjena" runat="server" Text="-"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=" Times   "></asp:Label>
             &nbsp
                <asp:Label ID="Label3" runat="server" Text="Average Score: "></asp:Label>
                <asp:Label ID="lblOcjena" runat="server" Text="Još nije ocjenjen"></asp:Label>
             </div>
    <br />
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
                <asp:Button ID="btnVoteArticle" runat="server" onclick="Button1_Click" Text="Grade Question" CssClass="btn" />
       </div>                 
 </div>
    </div>
        </div>

    <div class="container">
        <div class="span7">
    <hr />
     <asp:Label ID="lblAnswer" runat="server" Text=""><h4>ANSWERS ON QUESTION:</h4></asp:Label>
    <hr />
             </div>
    </div>

    <br />

     <div class="container">
         <div class="span7">
    <asp:Repeater ID="rprAnswers" runat="server" OnItemCommand="rprAnswers_ItemCommand" >
        <ItemTemplate>
                 
      <br />
            <div class="row">
            Answer:
          <h4> <%# Eval("Answer")%></h4>
                </div>
  <br />
            <div class="row">
      Answer Date:
       <h5> <%# Eval("Date")%></h5> 
         </div>
            <br />
          <div class="row">
       Answered By:
       <h5>  <%# Eval("Username")%></h5>

              </div>
        
            <br />
             <div class="row">
             Score:
         <h5>  <%# Eval("Score")%></h5>

                    </div>
                <div class="row">                
           <asp:LinkButton ID="UPAnswer" runat="server" Text="" CommandName="UPAnswer" CommandArgument='<%# Eval("AnswerId") + ";" +Eval("Score") %>'><img src="../Images/facebook-like.png" alt="Like" height="15px" width="20px" /></asp:LinkButton>
           <asp:LinkButton ID="DownAnswer" runat="server" Text="" CommandName="DownAnswer"  CommandArgument='<%# Eval("AnswerId") + ";" +Eval("Score")  %>'><img src="../Images/Dislike.png" alt="Dislike" height="15px" width="20px" /></asp:LinkButton>
 </div>
            
            <br />
            <br />
             </ItemTemplate>

    </asp:Repeater>


    
    <br />
         <div class="row">
    <asp:Label ID="lblInsertAnswer" runat="server" Font-Bold="True" Font-Size="Medium" 
        Text="Answer on Question:"></asp:Label>
    <br />
    <br />
  <asp:TextBox ID="txtAnswer" runat="server" MaxLength="3000" TextMode="MultiLine" style="resize:none" Height="83px" Width="278px" ></asp:TextBox>
    <br />
    <asp:Button ID="BtnInsert" runat="server" onclick="InsertAnswer_Click" 
        Text="Answer" Font-Size="Medium" CssClass="btn-primary" />

    <br />
             </div>
              </div>
          </div>
    <br />
    <br />

 


   <div id="Recommend">
       <div class="container">
        <div class="row">
            <div class="span6">

              
                       
                                <h5>StackOverflow Recommendation</h5>
                             
                            
                      
                                   
                                                <asp:DataList ID="stackOverflowList" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                      
                                                            <a href='http://stackoverflow.com/<%# Eval("question_timeline_url") %>' target="_blank">
                                                                <span class="label-bullet-blue">&nbsp;
                                                                </span>
                                                                <%# Eval("Title") %>
                                                            </a>
                                                      
                                                    </ItemTemplate>
                                                </asp:DataList>

                                         </div>
                            </div>
                        </div>
                    
   
                               
     </div>

     

</asp:Content>
