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
    public partial class Login : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);

        protected int checkUser(string username, string password)
        {
            int UserId = 0;
            string _username = username;
            string _password = password;

            connection.Open();
            SqlCommand cmd = new SqlCommand("Select UserId, Username, Firstname, Lastname, Email From Users Where " +
                           "Username = @username  and  Password = @Password", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            SqlParameter userNameParam = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 25 /* max length of field */ );
            SqlParameter userNameParam1 = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 25 /* max length of field */ );
            
            userNameParam.Value = _username;
            userNameParam1.Value = _password;

            SqlDataAdapter daUser = new SqlDataAdapter(cmd);
            SqlDataReader readerUser = cmd.ExecuteReader();
            string Firstname;
            string Lastname;
            string Username;
            string Email;
            while (readerUser.Read())
            {
               
                Firstname = readerUser["Firstname"].ToString();
                Lastname = readerUser["Lastname"].ToString();
                Username = readerUser["Username"].ToString();
                Email = readerUser["Email"].ToString();
                UserId = Convert.ToInt32(readerUser["UserId"]);
                Session["Firstname"] = Firstname;
                Session["Lastname"] = Lastname;
                Session["Username"] = Username;
                Session["UserId"] = UserId;
                Session["Email"] = Email;
            }

          
            return UserId;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int UserId = checkUser(UserName.Text, Password.Text);

            if (UserId == 0)
            {
               
                ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Pogresan Username ili Password!');", true);

            }
            else
            {
               


                Response.Redirect("~/Account/Index.aspx");
            }
        }

      
       

        
    }
}