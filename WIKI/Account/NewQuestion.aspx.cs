using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WIKI.Account
{
    public partial class NewQuestion : System.Web.UI.Page
    {
        int LastId = 0;
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            int UserId = Convert.ToInt32(Session["UserId"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                 int UserId = Convert.ToInt32(Session["UserId"]);
                if ((txtTitle.Text != "") && (txtBody.Text != ""))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Question (QuestionTitle, QuestionBody, UserId ,CreatedDate) VALUES (@QuestionTitle, @QuestionBody, @UserId, @CreatedDate); SELECT SCOPE_IDENTITY();");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@QuestionTitle", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@QuestionBody", txtBody.Text);                    
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    connection.Open();
                   
                    LastId = Convert.ToInt16(cmd.ExecuteScalar());

                    //MessageBox.Show("Članak uspješno unesen", "Important Message");
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Postavili ste pitanje!');", true);
                    connection.Close();
                    InsertTags();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Članak nije unesen!", "Important Message");
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Pitanje nije postavljeno!');", true);
                }
            }
            else
            {
                //MessageBox.Show("Unijeti text i Sadrzaj", "Important Message");
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Unijeti text i Sadrzaj!');", true);
            }
            ResetFields();
            BackOnQuestion();
        }

        protected void BackOnQuestion()

        {
            Response.Redirect("~/Account/AllQuestions.aspx");
        }

        protected void ResetFields()
        {
            txtTitle.Text = String.Empty;
            txtBody.Text = String.Empty;
            txtTag1.Text = String.Empty;
            txtTag2.Text = String.Empty;
            txtTag3.Text = String.Empty;
            txtTag4.Text = String.Empty;
            txtTag5.Text = String.Empty;
            txtTag6.Text = String.Empty;
            txtTag7.Text = String.Empty;
            txtTag8.Text = String.Empty;
            txtTag9.Text = String.Empty;
            txtTag10.Text = String.Empty;

        }

        private void InsertTags()
        {
           
            try
            {
                SqlCommand cmd = new SqlCommand("QuestionInsertTags");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@QuestionId", LastId);

                if (txtTag1.Text != "")
                    cmd.Parameters.AddWithValue("@Tag1", txtTag1.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag1", null);

                if (txtTag2.Text != "")
                    cmd.Parameters.AddWithValue("@Tag2", txtTag2.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag2", null);

                if (txtTag3.Text != "")
                    cmd.Parameters.AddWithValue("@Tag3", txtTag3.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag3", null);

                if (txtTag4.Text != "")
                    cmd.Parameters.AddWithValue("@Tag4", txtTag4.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag4", null);

                if (txtTag5.Text != "")
                    cmd.Parameters.AddWithValue("@Tag5", txtTag5.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag5", null);

                if (txtTag6.Text != "")
                    cmd.Parameters.AddWithValue("@Tag6", txtTag6.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag6", null);

                if (txtTag7.Text != "")
                    cmd.Parameters.AddWithValue("@Tag7", txtTag7.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag7", null);

                if (txtTag8.Text != "")
                    cmd.Parameters.AddWithValue("@Tag8", txtTag8.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag8", null);

                if (txtTag9.Text != "")
                    cmd.Parameters.AddWithValue("@Tag9", txtTag9.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag9", null);

                if (txtTag10.Text != "")
                    cmd.Parameters.AddWithValue("@Tag10", txtTag10.Text);
                else
                    cmd.Parameters.AddWithValue("@Tag10", null);


                connection.Open();
                cmd.ExecuteNonQuery();

                // MessageBox.Show("Kljucne rijeci unesene.", "Important Message");
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Kljucne rijeci unesene.');", true);
                //ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Članak uspješno unesen!');", true);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Kljucne rijeci NISU unesene.", "Important Message");
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Kljucne rijeci NISU unesene.');", true);
            }
            finally { connection.Close(); }
        }
    }
}