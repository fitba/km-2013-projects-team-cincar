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
    public partial class AllQuestions : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("Select QuestionId, QuestionTitle, QuestionBody from Question", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "Question");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            connection.Close();

        }

        protected void NewQuestion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/NewQuestion.aspx");
        }        
    }
}

