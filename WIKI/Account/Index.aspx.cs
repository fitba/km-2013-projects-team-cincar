using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WIKI.Helpers;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;




namespace WIKI.Account
{
    public partial class Index : Page
    {

        static string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);


        protected void Page_Load(object sender, EventArgs e)
        {
            MostReadArticle();



            PopularArticles();

            MostRecent();

            createIndex();

          if (!IsPostBack)

               
              bindData();

        }

        public DefaultViewModel Model;

        private string getSearchTerm()
        {
            return Request.QueryString["searchTerm"] ?? "";
        }

       
        //private string getSearchField()
        //{
        //    return Request.QueryString["searchField"] ?? "";
        //}
        //private string getSearchType()
        //{
        //    return Request.QueryString["type"] ?? "";
        ////}
        //private string getLimit()
        //{
        //    return Request.QueryString["limit"] ?? "";
        //}

        private void bindData()
        {
            Model = getDefaultViewModel(getSearchTerm()); //getSearchField(), getSearchType());

            //var limit = getLimit() == "" ? 15 : Convert.ToInt32(getLimit());
            //if (limit > 0)
            //{
            //    litDatabaseRecordsCount.Text =
            //      "<div class=\"margin_top10\">And <b>" + (Model.AllSampleData.Count() - limit) + "</b> more records... " +
            //      "(<a href=\"" + "../Account/Index.aspx" + "?limit=0\">See All</a>)</div>";
            //    lvDatabase.DataSource = Model.AllSampleData.Take(limit);
            //}
            //else
            //    lvDatabase.DataSource = Model.AllSampleData;
            //lvDatabase.DataBind();

            

            var searchIndex = Model.AllSearchIndexData;
           

            if (getSearchTerm() != string.Empty)
                searchIndex = Model.SampleSearchResults;

            lvSearchIndex.DataSource = searchIndex;
            lvSearchIndex.DataBind();

            //ddlSearchFields.DataValueField = "Value";
            //ddlSearchFields.DataTextField = "Text";
            //ddlSearchFields.DataSource = Model.SearchFieldList;
            //ddlSearchFields.DataBind();

            txtSearch.Text = getSearchTerm();
           // ddlSearchFields.SelectedValue = getSearchField();
            //chkSearchDefault.Checked = getSearchType() == "default";
        }

      

        private DefaultViewModel getDefaultViewModel(string searchTerm)//, string searchField, string type = "")
        {
            // create default Lucene search index directory
            if (!System.IO.Directory.Exists(LuceneSearch._luceneDir)) System.IO.Directory.CreateDirectory(LuceneSearch._luceneDir);
            

            // perform Lucene search
            IEnumerable<LuceneData> searchResults = new List<LuceneData>();

            //if (string.IsNullOrEmpty(type))
            //    searchResults = string.IsNullOrEmpty(searchField)
            //                       ? LuceneSearch.Search(searchTerm)
            //                       : LuceneSearch.Search(searchTerm, searchField);
            //else if (type == "default")

                searchResults = LuceneSearch.Search(searchTerm);                                                   //string.IsNullOrEmpty(searchField)
                                 //  ? 
                                  // : LuceneSearch.SearchDefault(searchTerm, searchField);

            // setup and return view model
            //var search_field_list = new
            //  List<SelectedList> {
            //                 new SelectedList {Text = "(All Fields)", Value = ""},
                             
            //                 new SelectedList {Text = "Name", Value = "Name"},
            //                 new SelectedList {Text = "Description", Value = "Description"},
                            

            //               };
            return new DefaultViewModel
            {
               AllSampleData = LuceneSearch.GetAllDataForLuceneIndex(),
                // AllSearchIndexData = LuceneSearch.GetAllIndexRecords(),
               // SampleData = new LuceneData { Id = 9, Name = "El-Paso", Description = "City in Texas" },
                SampleSearchResults = searchResults,
                //SearchFieldList = search_field_list,
            };
        }

     

        private void createIndex()
        {

            LuceneSearch.AddUpdateLuceneIndex(LuceneSearch.GetAllDataForLuceneIndex());
                     
        }


        private void addToIndex(LuceneData sampleData)
        {
            LuceneSearch.AddUpdateLuceneIndex(sampleData);
          //  litResult.Text = "Record was added to search index successfully!";
            bindData();
        }

        private void clearIndex()
        {
            if (LuceneSearch.ClearLuceneIndex())
             //   litResult.Text = "Search index was cleared successfully!";
            //else
            //    litResult.Text = "Index is locked and cannot be cleared, try again later or clear manually!";
            bindData();
        }

        private void clearIndexRecord(int id)
        {
            LuceneSearch.ClearLuceneIndexRecord(id);
          //  litResult.Text = "Search index record was deleted successfully!";
            bindData();
        }

        private void optimizeIndex()
        {
            LuceneSearch.Optimize();
         //   litResult.Text = "Search index was optimized successfully!";
            bindData();
        }

        // List views
        //protected void lvSearchIndex_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
        //{
        //    var recordId = (int)lvSearchIndex.DataKeys[e.ItemIndex].Value;
        //    clearIndexRecord(recordId);
        //}

        // Form events
        protected void CreateIndex_Click(object sender, EventArgs e)
        {
            createIndex();
       
        }
        protected void lnkOptimizeIndex_Click(object sender, EventArgs e)
        {
            optimizeIndex();
        }
        protected void lnkClearIndex_Click(object sender, EventArgs e)
        {
            clearIndex();
        }
        //protected void btnAddUpdate_Click(object sender, EventArgs e)
        //{
        //    int id;
        //    if (!int.TryParse(txtId.Text, out id))
        //    {
        //        litResultFail.Text = "'Id' must be a number!";
        //        return;
        //    }
        //    addToIndex
        //      (new LuceneData
        //      {
        //          Id = id,
        //          Name = txtName.Text,
        //          Description = txtDescription.Text
        //      });
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Account/Index.aspx?searchTerm=" + txtSearch.Text);
                       
                              
                              //+
                              //"&searchField=" + ddlSearchFields.SelectedValue);
                              
                              //+
                              //"&type=" + (chkSearchDefault.Checked ? "default" : "")
              //);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            createIndex();
            
        }


        protected void MostReadArticle()
        {
            int userId = Convert.ToInt32(Session["UserId"]);  
            DataSet ds1 = new DataSet();

            SqlCommand cmd = new SqlCommand("Select TOP(4) CategoryId,ArticleId,Title,Views from Article " +
                " ORDER BY Views DESC", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds1, "PopularniClanci");
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();
          
           
            connection.Close();
        }

        protected void PopularArticles()
        {

            DataSet ds = new DataSet();


            SqlCommand cmd = new SqlCommand("Select TOP (4) Article.Title, Article.ArticleId, AVG (Score) AS Average from Article FULL JOIN ArticleGrade ON Article.ArticleId=ArticleGrade.ArticleId GROUP BY Article.ArticleId, Article.Title ORDER BY Average DESC", connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PopularArticle");
            Repeater2.DataSource = ds;
            Repeater2.DataBind();


            connection.Close();

        }


        protected void MostRecent()

        {
            DataSet ds2 = new DataSet();


            SqlCommand cmd = new SqlCommand("Select TOP (4) Title, ArticleId,CreateDate from Article  ORDER BY CreateDate DESC", connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds2, "MostRecent");
            Repeater3.DataSource = ds2;
            Repeater3.DataBind();


            connection.Close(); 
        }



       

        public object AllSearchIndexData { get; set; }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            MostRecent();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            
            MostReadArticle();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            PopularArticles();
        }
    }
}