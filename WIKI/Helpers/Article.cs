using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WIKI.Helpers
{
    public class Article
    {
        string _body;
        string _title;
        string _articleid;
        int _views;
     
        

        public string Body
        {
            get { return this._body; }
            set { this._body = value; }
        }
        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        public string ArticleId
        {
            get { return this._articleid; }
            set { this._articleid = value; }
        }

        public int Views
        {
            get { return this._views; }
            set { this._views = value; }
        }

     
        



        }
      
    }
