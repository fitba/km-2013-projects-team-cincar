using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WIKI.Helpers
{
    public class QAService
    {

        public void GetQuestionById(int Id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);

            int _questionId = Id;

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select QuestionId from Question WHERE QuestionId=" + Id, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


        }
    }
}