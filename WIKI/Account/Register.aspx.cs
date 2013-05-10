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
    public partial class Register : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        
         protected int insertUser(string Username, string Password, string Firstname, string Lastname, string Email)
        {
            int UserId=0;

            string _username = Username;
            string _password = Password;
            string _firstname = Firstname;
            string _lastname = Lastname;
            string _email = Email;
            string username = null;
            SqlCommand cmd;
            SqlParameter userNameParam;
            SqlParameter userNameParam1;
            SqlParameter userNameParam2;
            SqlParameter userNameParam3;
            SqlParameter userNameParam4;

            if ((Firstname != "") && (Lastname != "") && (Username != "") && (Password != "") && (Password == ConfirmPassword.Text) && (Email != ""))
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("Select UserId, Username From Users Where " + // 
                                   "Username = @Username", connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                     userNameParam = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 25  );
                     userNameParam1 = cmd.Parameters.Add("@Firstname", SqlDbType.VarChar, 25  );
                     userNameParam2 = cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 25  );
                     userNameParam3 = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 25  );
                     userNameParam4 = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 25);
                    userNameParam.Value = _username;
                    userNameParam1.Value = _firstname;
                    userNameParam2.Value = _lastname;
                    userNameParam3.Value = _password;
                    userNameParam4.Value = _email;


                    SqlDataAdapter daUser = new SqlDataAdapter(cmd);
                    SqlDataReader readerUser = cmd.ExecuteReader();
                    
                    while (readerUser.Read())
                    {
                        username = readerUser["Username"].ToString();
                        UserId = Convert.ToInt32(readerUser["UserId"]);
                    }
                    readerUser.Close();
                }
                catch (Exception ex) { } 

                if (username == null)//
                {
                    try
                    {
                        cmd = new SqlCommand("Insert INTO Users (Username, Password, Firstname, Lastname, Email) Values " +
                            "(@Username,@Password,@Firstname,@Lastname,@Email) ", connection);

                        userNameParam = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam1 = cmd.Parameters.Add("@Firstname", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam2 = cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam3 = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam4 = cmd.Parameters.Add("@Email", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam.Value = _username;
                        userNameParam1.Value = _firstname;
                        userNameParam2.Value = _lastname;
                        userNameParam3.Value = _password;
                        userNameParam4.Value = _email;
                        cmd.ExecuteNonQuery();


                        cmd = new SqlCommand("Select UserId, Username, Firstname, Lastname, Email From Users Where " + // 
                              "Username = @Username", connection);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        userNameParam = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 25 /* max length of field */ );
                        userNameParam.Value = _username;

                        SqlDataReader readerUser1 = cmd.ExecuteReader();
                        username = null;
                        while (readerUser1.Read())
                        {
                            Firstname = readerUser1["Firstname"].ToString();
                            Lastname = readerUser1["Lastname"].ToString();
                            Username = readerUser1["Username"].ToString();
                            Email = readerUser1["Email"].ToString();
                            UserId = Convert.ToInt32(readerUser1["UserId"]);
                            Session["Firstname"] = Firstname;
                            Session["Lastname"] = Lastname;
                            Session["Username"] = Username;
                            Session["Email"] = Email;
                            Session["UserId"] = UserId;
                        }
                        readerUser1.Close();

                      
                       

                        connection.Close();
                        Response.Redirect("~/Account/Profile.aspx");
                    }
                    catch (Exception ex) { }
                }
                else { //MessageBox.Show("Korisničko ime zauzeto"); 
                    ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Username already exist!');", true); }
            }
            else
            { 
               
            ClientScript.RegisterStartupScript(typeof(Page), "myscript", "alert('Greska');", true);
            }//
            return UserId;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetFields()

        {
            Firstname.Text = String.Empty;
            Lastname.Text = String.Empty;
            Username.Text = String.Empty;
            Password.Text = String.Empty;
            Email.Text = String.Empty;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            insertUser(Username.Text,Password.Text, Firstname.Text, Lastname.Text, Email.Text);

           ResetFields();
        }
    }
}