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
    public partial class Profile1 : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["Username"];
            if (username != null)
            {
                LoadCategories();
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Logirajte se !');window.location.href = '../Account/Login.aspx'", true);
            }

        }

        void LoadCategories()
        {
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("Select CategoryId, Title from Category", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "Category");
          
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            connection.Close();

        }

        protected void btnNewArticle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/NewArticle.aspx");
        }

    
    }
}
