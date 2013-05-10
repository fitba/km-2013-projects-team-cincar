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
    public partial class CategoryDetails : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            
          
            string strSel;
            string Category = Request.QueryString["CategoryId"];
           



            DataSet dsCat = new DataSet();
            DataTable dtCat = new DataTable();
           
            SqlDataAdapter daCat = new SqlDataAdapter();

            daCat.SelectCommand = new SqlCommand (" Select CategoryId, Title from Category where CategoryId = " + Category, connection);
            daCat.Fill(dsCat, "Category");
            dtCat = dsCat.Tables["Category"];

            foreach (DataRow dr in dtCat.Rows)
            {
               lblKategorija.Text = dr["Title"].ToString();
            }

            

           
            
            connection.Close();
           
            DataSet ds = new DataSet();
        
            connection.Open();
         

            SqlCommand cmd = new SqlCommand("Select Article.ArticleId,Article.Title,Article.CreateDate,Article.UserId,Users.Username from Article FULL JOIN Users ON Article.UserId=Users.UserId where CategoryId=" + Category + "Order by CreateDate DESC", connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
         
        }

     

        }

    
    }
