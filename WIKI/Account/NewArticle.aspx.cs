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
    public partial class NewArticle : System.Web.UI.Page
    {

        int LastId = 0;
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        string KljucnaRijec1 = "";
        string KljucnaRijec2 = "";
        string KljucnaRijec3 = "";
        string KljucnaRijec4 = "";
        string KljucnaRijec5 = "";
        string KljucnaRijec6 = "";
        string KljucnaRijec7 = "";
        string KljucnaRijec8 = "";
        string KljucnaRijec9 = "";
        string KljucnaRijec10 = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            if (username == null)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logirajte se !');window.location.href = '../Account/Login.aspx'", true);
            }
        }

        protected void ResetFields()
        {
            txtNaslov.Text = String.Empty;
            txtSadrzaj.Text = String.Empty;
            txtKljucnaRijec1.Text = String.Empty;
            txtKljucnaRijec2.Text = String.Empty;
            txtKljucnaRijec3.Text = String.Empty;
            txtKljucnaRijec4.Text = String.Empty;
            txtKljucnaRijec5.Text = String.Empty;
            txtKljucnaRijec6.Text = String.Empty;
            txtKljucnaRijec7.Text = String.Empty;
            txtKljucnaRijec8.Text = String.Empty;
            txtKljucnaRijec9.Text = String.Empty;
            txtKljucnaRijec10.Text = String.Empty;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((txtNaslov.Text != "") && (txtSadrzaj.Text != ""))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Article (Title, Body, CategoryId, UserId ,CreateDate) VALUES (@Title, @Body, @CategoryId, @UserId, @Createdate); SELECT SCOPE_IDENTITY();");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Title", txtNaslov.Text);
                    cmd.Parameters.AddWithValue("@Body", txtSadrzaj.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", DropDownCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                    connection.Open();
                 
                    LastId = Convert.ToInt16(cmd.ExecuteScalar());

                    
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Article Created!');", true);
                    connection.Close();
                    insertKljucneRijeci();
                }
                catch (Exception ex)
                {
                    
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('New Article Failed!');", true);
                }
            }
            else
            {
               
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Please enter Title and Content!');", true);
            }
            ResetFields();
        }

        public void FillDropDownList()
        {
            SqlCommand cmd = new SqlCommand("Select CategoryId, Title from Category", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownCategory.DataSource = ds.Tables[0];
            DropDownCategory.DataTextField = "Title";
            DropDownCategory.DataValueField = "CategoryId";
            DropDownCategory.DataBind();
        }

        private void insertKljucneRijeci()
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("InsertTags");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                cmd.Parameters.AddWithValue("@ArticleId", LastId);

                if (txtKljucnaRijec1.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec1", txtKljucnaRijec1.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec1", null);

                if (txtKljucnaRijec2.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec2", txtKljucnaRijec2.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec2", null);

                if (txtKljucnaRijec3.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec3", txtKljucnaRijec3.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec3", null);

                if (txtKljucnaRijec4.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec4", txtKljucnaRijec4.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec4", null);

                if (txtKljucnaRijec5.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec5", txtKljucnaRijec5.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec5", null);

                if (txtKljucnaRijec6.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec6", txtKljucnaRijec6.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec6", null);

                if (txtKljucnaRijec7.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec7", txtKljucnaRijec7.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec7", null);

                if (txtKljucnaRijec8.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec8", txtKljucnaRijec8.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec8", null);

                if (txtKljucnaRijec9.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec9", txtKljucnaRijec9.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec9", null);

                if (txtKljucnaRijec10.Text != "")
                    cmd.Parameters.AddWithValue("@KljucnaRijec10", txtKljucnaRijec10.Text);
                else
                    cmd.Parameters.AddWithValue("@KljucnaRijec10", null);


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

        protected void Button3_Click1(object sender, EventArgs e)
        {
           

        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
        }

       

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void DropDownCategory_Init(object sender, EventArgs e)
        {
            FillDropDownList();
        }

        protected void Button3_Click2(object sender, EventArgs e)
        {
            insertKljucneRijeci();
        }
    }
}