using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WIKI.Helpers
{
    public class QAQuestion
    {




        int _questionid;
        string _questiontitle;
        string _questionbody;
        string _createddate;
        int _numofviews;
        string _username;
        int _userid;
        int _brojOdgovora;
        int _brojOcjena;
        int _likes;
        List<QATag> _tag = new List<QATag>();

        public int QuestionId
        
        { 
            get { return this._questionid; } 
            set { this._questionid = value; } 
        }

        public string QuestionTitle 
        
        { 
            get { return this._questiontitle; }
            set { this._questiontitle = value; }
        }

        public string QuestionBody
        
        {
            get { return this._questionbody; }
            set { this._questionbody = value; }
        }

        public string CreatedDate 
        
        {
            get { return this._createddate; }
            set { this._createddate = value; }
        }

        public int NumOfViews
        
        {
            get { return this._numofviews; }
            set {this._numofviews=value;}
        }
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        public int UserId
        {
            get { return this._userid; }
            set { this._userid = value; }
        }



        public int BrojOdgovora
        {
            get { return this._brojOdgovora; }
            set { this._brojOdgovora = value; }
        }

        public int BrojOcjena
        {
            get { return this._brojOcjena; }
            set { this._brojOcjena = value; }
        }

        public int Likes
        {
            get { return this._likes; }
            set { this._likes = value; }
        }

        public List<QATag> Tag
        {
            get { return this._tag; }
            set { this._tag = value; }
        }


       
        

       
    }


       
        }
    

