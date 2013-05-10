using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WIKI.Helpers;

namespace WIKI.Account
{
    public partial class EditArticle : System.Web.UI.Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);



       
        List<Article> body = new List<Article>();
        Article article = new Article();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {
                string Article = Request.QueryString["ArticleId"];
                string username = (string)Session["Username"];
               if (username !=null)

               {
                  
            
                    DataSet ds = new DataSet();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Article.ArticleId As ArticleId, Article.Title AS Title, Article.Body AS Body, Article.CreateDate AS CreateDate, Users.UserId AS UserId, Users.Firstname, Users.Lastname, Users.Username"
                                 + " FROM Article INNER JOIN Users ON Article.UserId = Users.UserId WHERE Article.ArticleId=" + Article, connection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNaslov.Text = reader["Title"].ToString();
                        txtSadrzaj.Text = reader["Body"].ToString();

                        article.Body = reader["Body"].ToString();
                        article.Title = reader["Title"].ToString();

                        body.Add(article);
                      
                        reader.Close();
                        connection.Close();
                    }

                   
                    connection.Close();
                }

                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logirajte se !');window.location.href = '../Account/Login.aspx'", true);
                }

            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Article = Request.QueryString["ArticleId"];
            string username = (string)Session["Username"];


            string UpdateTitle = txtNaslov.Text;
            string UpdateBody = txtSadrzaj.Text;
            string UpdateTime = DateTime.Now.ToString();
            

                if ((txtNaslov.Text != "") && (txtSadrzaj.Text != ""))

           

                  

                try
                {



                    SqlCommand cmd = new SqlCommand("UPDATE Article SET Title ='" + UpdateTitle + "', Body = '" + UpdateBody + "', ModifiedBy ='" + username + "', ModifiedOn ='" + UpdateTime + "' WHERE ArticleId =" + Article, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    

                  

                     connection.Open();
                     cmd.ExecuteNonQuery();


                   
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Članak je editovan!');", true);
                    connection.Close();

                   
                }
                catch (Exception ex)
                {
                   
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Članak nije editovan!');", true);
                }
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Profile.aspx");
        }
          

        }
    }

    