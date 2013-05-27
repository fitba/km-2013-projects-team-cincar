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
using System.Web.UI.HtmlControls;




namespace WIKI.Account
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            string Article = Request.QueryString["ArticleId"];

            string views = "0";

            
            List<Article> body = new List<Article>();
            Article article = new Article();

            if (!IsPostBack)
            {

               
                DataSet ds = new DataSet();
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.Article.ArticleId As ArticleId, dbo.Article.Title AS Title, dbo.Article.Body AS Body, dbo.Article.CreateDate AS CreateDate,dbo.Article.Views AS Views, dbo.Users.UserId AS UserId, dbo.Users.Firstname, dbo.Users.Lastname, dbo.Users.Username"
                             + " FROM dbo.Article INNER JOIN dbo.Users ON dbo.Article.UserId = dbo.Users.UserId WHERE dbo.Article.ArticleId=" + Article, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
                refreshVotingData();

                List<ATags> taglist = new List<ATags>();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if
                     (reader["Views"].ToString() != "")

                        views = reader["Views"].ToString();
                    else
                        views = "0";

               
                    article.Title = reader["Title"].ToString();
                    article.Body = reader["Body"].ToString();
                    article.Views = Convert.ToInt32(reader["Views"].ToString());

                    

                         
                   
                    body.Add(article);
                    Repeater1.DataSource = body;
                    Repeater1.DataBind();

                    
                    lblDate.Text = reader["CreateDate"].ToString();
                    lblAutor.Text = reader["Firstname"].ToString() + " " + reader["Lastname"].ToString() + " ";
                    lblViews.Text = reader["Views"].ToString();

                    reader.Close();
                    connection.Close();
                    UpdateViews(views);
                  
                  

                    if (username != null) 
                    {
                    
                    }
                }

               
                lblTags.Text = "";
              
                GetTagInArticle();
                connection.Close();


                //Preporuka Wikipedia
                WikiRecommendation(taglist, article.Title);

               

               
            }
        }


        private void WikiRecommendation(List<ATags> taglist, string title)
        {
           

            List<string> words = new List<string>();

            foreach (ATags t in taglist)
            {
                if (t.Name.Length >= 4)
                    words.Add(t.Name);
            }

            words.Add(title);
            words = words.Distinct().ToList();

            ExternalIntegration integration = new ExternalIntegration();
            List<WikiP> articlesWiki = new List<WikiP>();
            List<WikiP> articlesWikiRecommend = new List<WikiP>();

            foreach (string w in words)
            {
                articlesWiki.Clear();
                articlesWiki.AddRange(integration.SearchWikipedia(w));
                articlesWikiRecommend.AddRange(articlesWiki.Take(3).ToList());
            }

            articlesWikiRecommend = articlesWikiRecommend.Distinct().ToList();
            wikiList.DataSource = articlesWikiRecommend;
            wikiList.DataBind();

          
        }
       

        protected void UpdateViews(string Views)  
        {
            string _views = Views;
            string ArticleId = Request.QueryString["ArticleId"];
            int i = Convert.ToInt32(_views);
            i++;
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Article SET Article.Views=" + i + " WHERE Article.ArticleId=" + ArticleId, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
        }

            private void refreshVotingData ()
            {

                string Article = Request.QueryString["ArticleId"];
                SqlCommand cmdProsjek = new SqlCommand("SELECT AVG (Score) AS Prosjek, COUNT (Score) AS BrojOcjena from ArticleGrade where ArticleId=" + Article, connection);
                SqlDataAdapter daProsjek = new SqlDataAdapter(cmdProsjek);
                SqlDataReader readerProsjek = cmdProsjek.ExecuteReader();

                if (readerProsjek.Read())
                {
                    lblOcjena.Text = readerProsjek["Prosjek"].ToString();
                    lblBrojOcjena.Text = readerProsjek["BrojOcjena"].ToString();
                }
                readerProsjek.Close();

             
            }

            protected void txtNaslov_TextChanged(object sender, EventArgs e)
            {

            }

          
            protected void btnEditArticle_Click(object sender, EventArgs e)
        {
            string Article = Request.QueryString["ArticleId"];
            Response.Redirect("~/Account/EditArticle.aspx?ArticleId="+Article);
        }
            

            protected void btnVote_Click(object sender, EventArgs e)
            { 
            
            }

            protected void Button1_Click(object sender, EventArgs e)
            {

          
            string Article = Request.QueryString["ArticleId"];
           
            string username = (string)Session["Username"];
            if (username != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into ArticleGrade (ArticleId,UserId,Score) VALUES (@ArticleId,@UserId,@Score)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(Article));
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                    cmd.Parameters.AddWithValue("@Score", Convert.ToInt32(DropDownListVoteArticle.SelectedValue));
                    
                    connection.Open();
                    cmd.ExecuteNonQuery();

                   
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Article graded!');", true);
                    refreshVotingData();
                }
                catch (Exception ex) { 
              
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Failed, Article already graded!');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logirajte se !');", true);
                
            }
        }

            

            private void GetTagInArticle()
            {

                List<ATags> taglist = new List<ATags>();

                string Article = Request.QueryString["ArticleId"];
                try
                {
                    SqlCommand cmdKljucneRijeci = new SqlCommand("GetTagInArticle");
                    cmdKljucneRijeci.CommandType = CommandType.StoredProcedure;
                    cmdKljucneRijeci.Connection = connection;

                    cmdKljucneRijeci.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(Article));

                    connection.Open();
                    SqlDataAdapter daKljucneRijeci = new SqlDataAdapter(cmdKljucneRijeci);
                    SqlDataReader readerKljucneRijeci = cmdKljucneRijeci.ExecuteReader();

                   

                    while (readerKljucneRijeci.Read())
                    {
                        lblTags.Text = lblTags.Text + "  |   " + readerKljucneRijeci["Tag"].ToString() + "";

                        ATags tags = new ATags();

                        tags.Name = readerKljucneRijeci["Tag"].ToString();



                        taglist.Add(tags);
                        
                    }
                    readerKljucneRijeci.Close();

                 


                }
                catch (Exception ex)
                {
                   
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Failed!');", true);
                }
                finally { connection.Close(); }

            }





         
    }
    }
