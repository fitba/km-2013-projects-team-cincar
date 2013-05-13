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
            createIndex();

         if (!IsPostBack)
         {
               
              bindData1();

        }

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



        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Account/AllQuestions.aspx?searchQ=" + txtSearch.Text);
                       
        }


        public Model1 Model;

        private string getSearchQ()
        {
            return Request.QueryString["searchQ"] ?? "";
        }


      

        private void bindData1()
        {
            Model = getModel1(getSearchQ()); 

         



            var searchIndex = Model.AllSearchIndexData;


            if (getSearchQ() != string.Empty)
                searchIndex = Model.SampleSearchResults;

            lvSearchIndex.DataSource = searchIndex;
            lvSearchIndex.DataBind();

        
            txtSearch.Text = getSearchQ();
         
        }



        private Model1 getModel1(string searchQ)//, string searchField, string type = "")
        {
            // create default Lucene search index directory
            if (!System.IO.Directory.Exists(LuceneQ._luceneDir)) System.IO.Directory.CreateDirectory(LuceneQ._luceneDir);


            // perform Lucene search
            IEnumerable<LuceneQData> searchResults = new List<LuceneQData>();


            searchResults = LuceneQ.Search(searchQ);                                                 
     
            return new Model1
            {
                AllSampleData = LuceneQ.GetAllDataForLuceneIndex(),
             
                SampleSearchResults = searchResults,
             
            };
        }



        private void createIndex()
        {

            LuceneQ.AddUpdateLuceneIndex(LuceneQ.GetAllDataForLuceneIndex());

        }


        private void addToIndex(LuceneQData sampleData)
        {
            LuceneQ.AddUpdateLuceneIndex(sampleData);
            
            bindData1();
        }

        private void clearIndex()
        {
            if (LuceneQ.ClearLuceneIndex())
         
                bindData1();
        }

        private void clearIndexRecord(int id)
        {
            LuceneQ.ClearLuceneIndexRecord(id);
           
            bindData1();
        }

        private void optimizeIndex()
        {
            LuceneQ.Optimize();
          
            bindData1();
        }

    
        // Form events
        protected void CreateIndex_Click(object sender, EventArgs e)
        {
            createIndex();

        }
      

    }
}

