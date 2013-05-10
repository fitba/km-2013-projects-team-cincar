using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WIKI.Helpers;

namespace WIKI.Account
{
    public partial class QuestionDetails : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);

        
      

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            string Question = Request.QueryString["QuestionId"];
            string numviews = "0";
            showAnswers(Convert.ToInt32(Question));
        
            
            List<QAQuestion> questionbody = new List<QAQuestion>();
            QAQuestion question = new QAQuestion();

            QAAnswer answer = new QAAnswer();
            List<QAAnswer> answerlist = new List<QAAnswer>();

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT  dbo.Question.QuestionId As QuestionId, dbo.Question.QuestionTitle AS QuestionTitle, dbo.Question.QuestionBody AS QuestionBody, dbo.Question.CreatedDate AS CreatedDate,dbo.Question.NumOfViews AS NumOfViews, dbo.Users.UserId AS UserId, dbo.Users.Firstname, dbo.Users.Lastname, dbo.Users.Username"
                             + " FROM dbo.Question INNER JOIN dbo.Users ON dbo.Question.UserId = dbo.Users.UserId WHERE dbo.Question.QuestionId=" + Question, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                refreshVotingData();


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if
                   (reader["NumOfViews"].ToString() != "")

                        numviews = reader["NumOfViews"].ToString();
                    else
                        numviews = "0";


                   
                    question.QuestionTitle = reader["QuestionTitle"].ToString();
                    question.QuestionBody = reader["QuestionBody"].ToString();
                    question.NumOfViews = Convert.ToInt32(reader["NumOfViews"].ToString());
                    if
                      (reader["NumOfViews"].ToString() != "")
                        
                       numviews = reader["NumOfViews"].ToString();
                   else
                       numviews = "0";


                    questionbody.Add(question);

                    Repeater1.DataSource = questionbody;
                    Repeater1.DataBind();


                    lblDate.Text = reader["CreatedDate"].ToString();
                    lblAutor.Text = reader["Firstname"].ToString() + " " + reader["Lastname"].ToString() + "";
                    

                  

                    reader.Close();
                    connection.Close();
                    UpdateViews(numviews); 

                  
                }

               
                lblKljucneRijeci.Text = "";
                GetTagInQuestions();
                connection.Close();
            }
        }


     
        

        protected void UpdateViews(string NumOfViews)  
        {
            string _numofviews = NumOfViews;
            string QuestionId = Request.QueryString["QuestionId"];
            int i = Convert.ToInt32(_numofviews);
            i++;
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Question SET Question.NumOfViews=" + i + " WHERE Question.QuestionId=" + QuestionId, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
        }


         private void GetTagInQuestions()
            {
                string Question = Request.QueryString["QuestionId"];
                try
                {
                    SqlCommand cmdKljucneRijeci = new SqlCommand("GetTagInQuestions");
                    cmdKljucneRijeci.CommandType = CommandType.StoredProcedure;
                    cmdKljucneRijeci.Connection = connection;

                    cmdKljucneRijeci.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Question));

                    connection.Open();
                    SqlDataAdapter daKljucneRijeci = new SqlDataAdapter(cmdKljucneRijeci);
                    SqlDataReader readerKljucneRijeci = cmdKljucneRijeci.ExecuteReader();
                    while (readerKljucneRijeci.Read())
                    {
                        lblKljucneRijeci.Text = lblKljucneRijeci.Text + "  |   " + readerKljucneRijeci["Tag"].ToString() + "";
                      
                    }
                    readerKljucneRijeci.Close();

                    


                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Greska!", "Important Message");
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Failed!');", true);
                }
                finally { connection.Close(); }

            }

         private void refreshVotingData()
         {

             string Question = Request.QueryString["QuestionId"];
             SqlCommand cmdProsjek = new SqlCommand("SELECT AVG (Score) AS Prosjek, COUNT (Score) AS BrojOcjena from QuestionGrade where QuestionId=" + Question, connection);
             SqlDataAdapter daProsjek = new SqlDataAdapter(cmdProsjek);
             SqlDataReader readerProsjek = cmdProsjek.ExecuteReader();

             if (readerProsjek.Read())
             {
                 lblOcjena.Text = readerProsjek["Prosjek"].ToString();
                 lblBrojOcjena.Text = readerProsjek["BrojOcjena"].ToString();
             }
             readerProsjek.Close();
         }

         protected void Button1_Click(object sender, EventArgs e)
         {

            
             string Question = Request.QueryString["QuestionId"];
           
             string username = (string)Session["Username"];
             if (username != null)
             {

                 try
                 {
                     SqlCommand cmd = new SqlCommand("Insert into QuestionGrade (QuestionId,UserId,Score) VALUES (@QuestionId,@UserId,@Score)");
                     cmd.CommandType = CommandType.Text;
                     cmd.Connection = connection;
                     cmd.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Question));
                     cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                     cmd.Parameters.AddWithValue("@Score", Convert.ToInt32(DropDownListVoteArticle.SelectedValue));

                     connection.Open();
                     cmd.ExecuteNonQuery();

                     
                     ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Question graded!');", true);

                     refreshVotingData();
                 }
                 catch (Exception ex)
                 {
                  
                     ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Already graded!');", true);
                 }
             }
             else
             {
                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logirajte se !');", true);
                 
             }
         }



         protected void showAnswers(int Question)  
         {
             QAAnswer answer = new QAAnswer();
             List<QAAnswer> answerlist = new List<QAAnswer>();


             int _question = Question;

             DataSet ds = new DataSet();
             DataTable dt = new DataTable();
             DataRow dr = null;

             SqlCommand cmd = new SqlCommand("SELECT  dbo.Answer.AnswerId, dbo.Answer.Answer, dbo.Answer.QuestionId, dbo.Answer.UserId," +
                 "dbo.Answer.Date,dbo.Answer.Score, dbo.Users.Username FROM dbo.Answer INNER JOIN dbo.Question ON dbo.Answer.QuestionId = dbo.Question.QuestionId " +
                 " INNER JOIN dbo.Users ON dbo.Answer.UserId = dbo.Users.UserId" + " Where dbo.Question.QuestionId=@QuestionId" , connection);

             cmd.Parameters.AddWithValue("@QuestionId", _question);

             
             dt.Columns.Add("Answer");
             dt.Columns.Add("Date");
             dt.Columns.Add("Score");
             dt.Columns.Add("Username");
             

             connection.Open();
             try
             {
                 SqlDataAdapter da = new SqlDataAdapter(cmd);

                 da.Fill(ds, "Answer");
                 da.Fill(dt);

                 SqlDataReader reader = cmd.ExecuteReader();
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 
              
                 {
                     dr = dt.NewRow();
                     dr["AnswerId"] = ds.Tables[0].Rows[i]["AnswerId"].ToString();                    
                     dr["Answer"] = ds.Tables[0].Rows[i]["Answer"].ToString();
                     dr["Date"] = ds.Tables[0].Rows[i]["Date"].ToString();
                     dr["Score"] = ds.Tables[0].Rows[i]["Score"].ToString();
                     dr["Username"] = ds.Tables[0].Rows[i]["Username"].ToString();

                   

                     answer = new QAAnswer();
                     answer.AnswerId = Convert.ToInt32(dr["AnswerId"].ToString());
                     answer.Answer = dr["Answer"].ToString();
                     answer.Date = dr["Date"].ToString();
                     answer.Score = Convert.ToInt32(dr["Score"]);
                     answer.Username = dr["Username"].ToString();
                     

                     answerlist.Add(answer);

                 }

                 
             }
             catch (Exception e) { }
             finally
             {
                 connection.Close();
             }
             rprAnswers.DataSource = answerlist;
             rprAnswers.DataBind();
         }


            protected void InsertAnswer()
         {
             QAAnswer answer = new QAAnswer();
             string Question = Request.QueryString["QuestionId"];
             int UserId = Convert.ToInt32(Session["UserId"]);
             int LastId = 0;
             
             answer.Answer = txtAnswer.Text;
             answer.Date = DateTime.Now.ToString();
             answer.QuestionId = Convert.ToInt32(Question);
             answer.UserId = UserId;


             try
             {
                 SqlCommand cmd = new SqlCommand("INSERT INTO Answer (Answer, QuestionId, UserId, Date) VALUES (@Answer, @QuestionId, @UserId, @Date); SELECT SCOPE_IDENTITY();");
                 cmd.CommandType = CommandType.Text;
                 cmd.Connection = connection;

                 cmd.Parameters.AddWithValue("@Answer", answer.Answer);
                 cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                 cmd.Parameters.AddWithValue("@QuestionId", answer.QuestionId);
                 cmd.Parameters.AddWithValue("@UserId", answer.UserId);

                 connection.Open();
                 //cmd.exExecuteNonQuery();
                 LastId = Convert.ToInt16(cmd.ExecuteScalar());

                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('You answer on question!');", true);
                 txtAnswer.Text = "";
                 connection.Close();

                
             }
             catch (Exception ex)
             {
                 //MessageBox.Show("Članak nije unesen!", "Important Message");
                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Failed!');", true);
             }
             finally { connection.Close(); }
         }



            //protected void txtNaslov_TextChanged(object sender, EventArgs e)
            //{

            //}

         protected void InsertAnswer_Click(object sender, EventArgs e)
         {
             string username = (string)Session["Username"];
             string Question = Request.QueryString["QuestionId"];

             if (username != null)
             {
                 if (txtAnswer.Text != "")
                 {
                     InsertAnswer();
                     Response.Redirect("../Account/QuestionDetails.aspx?QuestionId="+ Question);
                 }
                 else { ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Please enter text!');", true); }
             }
             else { ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Login!');", true); }
            
             
         }


         protected void insertAnswerVoteDOWN(int QuestionId, int TotalVotes)
         {

             int _questionid = QuestionId;
             int _brojOcjena = TotalVotes;
             string username = (string)Session["Username"];
             int UserId = Convert.ToInt32(Session["UserId"]);

             _brojOcjena--;

             if (username != null)
             {

                 try
                 {
                     SqlCommand cmd1 = new SqlCommand("Update Answer SET dbo.Answer.Score=@Score Where dbo.Answer.AnswerId=@QuestionId");
                     cmd1.CommandType = CommandType.Text;
                     cmd1.Connection = connection;
                     cmd1.Parameters.AddWithValue("@QuestionId", _questionid);
                     cmd1.Parameters.AddWithValue("@Score", _brojOcjena);

                     connection.Open();
                     cmd1.ExecuteNonQuery();
                     connection.Close();


                     ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Success');", true);


                 }

                 catch (Exception ex)
                 {

                     ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Failed');", true);
                 }




                 finally { connection.Close(); }
             }
             else
             {
                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Login!');", true);

             }

         }
         
         

         protected void insertAnswerVoteUP(int QuestionId, int TotalVotes)
         {
             int _questionid = QuestionId;
             int _brojOcjena = TotalVotes;
            
             _brojOcjena++;




             try
             {
                 SqlCommand cmd1 = new SqlCommand("Update Answer SET dbo.Answer.Score=@Score Where dbo.Answer.AnswerId=@QuestionId");
                 cmd1.CommandType = CommandType.Text;
                 cmd1.Connection = connection;
                 cmd1.Parameters.AddWithValue("@QuestionId", _questionid);
                 cmd1.Parameters.AddWithValue("@Score", _brojOcjena);

                 connection.Open();
                 cmd1.ExecuteNonQuery();
                 connection.Close();

                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Graded');", true);

             }


             catch (Exception ex)
             {

                 ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Already Grade');", true);
             }

             finally
             {

                 connection.Close();


             }
         }
         
         protected void rprAnswers_ItemCommand(object source, RepeaterCommandEventArgs e)
         {
            
             string Question = Request.QueryString["QuestionId"];
             int UserId = Convert.ToInt32(Session["UserId"]);
             string username = (string)Session["Username"];

             string isactivestatus = Convert.ToString(e.CommandArgument);

             string[] arg = new string[2];

             arg = isactivestatus.Split(';');

             int IdOdgovor = Convert.ToInt32(arg[0]);
             int UkupnoOcjena = Convert.ToInt32(arg[1]);



             if (username != null)
             {
                 switch (e.CommandName)
                 {
                     case "UPAnswer": insertAnswerVoteUP(IdOdgovor, UkupnoOcjena);
                         //Response.Redirect(Request.RawUrl);
                         break;
                     case "DownAnswer": insertAnswerVoteDOWN(IdOdgovor, UkupnoOcjena);
                         //Response.Redirect(Request.RawUrl); 
                         break;

                 }
             }
             else { ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logiraj se!');", true); }


         }

        
      

        

    }


    }
