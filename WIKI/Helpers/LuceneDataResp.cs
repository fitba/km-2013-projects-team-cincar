//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using WIKI.Helpers;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Data;


//namespace WIKI.Helpers
//{

   


//    public static class LuceneDataResp
//    {


//        //public static LuceneData Get(int id)
//        //{


//        //    return GetAllDataForLuceneIndex().SingleOrDefault(x => x.Id.Equals(id));



//        //}


//        public static List<LuceneData> GetArticle()
//        {

//               string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
//        SqlConnection connection = new SqlConnection(connStr);

//            List<LuceneData> obj1 = new List<LuceneData>();

//            DataTable dt = new DataTable();
//            SqlConnection con = new SqlConnection(connStr);
//            con.Open();
//            SqlCommand cmd = new SqlCommand("select * from Article", con);
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            da.Fill(dt);
//            if (dt.Rows.Count > 0)
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    LuceneData ga = new LuceneData();
//                    ga.Id = Convert.ToInt32(dt.Rows[i]["ArticleId"].ToString());
//                    ga.Name = dt.Rows[i]["Title"].ToString();
//                    ga.Description = dt.Rows[i]["Body"].ToString();
                   
//                    obj1.Add(ga);
//                }
//            }
//            return obj1;
//        }


//        public static List<LuceneData> GetQuestion()
//        {

//            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
//            SqlConnection connection = new SqlConnection(connStr);

//            List<LuceneData> obj2 = new List<LuceneData>();

//            DataTable dt = new DataTable();
//            SqlConnection con = new SqlConnection(connStr);
//            con.Open();
//            SqlCommand cmd = new SqlCommand("select * from Question", con);
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            da.Fill(dt);
//            if (dt.Rows.Count > 0)
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    LuceneData gq = new LuceneData();
//                    gq.Id = Convert.ToInt32(dt.Rows[i]["QuestionId"].ToString());
//                    gq.Name = dt.Rows[i]["QuestionTitle"].ToString();
//                    gq.Description = dt.Rows[i]["QuestionBody"].ToString();
                    
//                    obj2.Add(gq);
//                }
//            }
//            return obj2;
//        }


//        public static List<LuceneData> GetAllDataForLuceneIndex()
//        {
//            List<LuceneData> temp = new List<LuceneData>();
//            temp.AddRange(GetArticle());
//            temp.AddRange(GetQuestion());
//            return temp;
//        }

      
      

      
           


      
    

//        }
//    }
