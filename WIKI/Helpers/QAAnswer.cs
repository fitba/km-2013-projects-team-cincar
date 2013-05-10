using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIKI.Helpers
{
    public class QAAnswer
    {
        int _answerid;
        string _answer;
        int _questionid;
        int _userid;
        string _username;
        string _date;
        int _score;

        public int AnswerId
        {
            get { return this._answerid; }
            set { this._answerid = value; }
        }

        public string Answer
        {
            get { return this._answer; }
            set { this._answer = value; }
        }

        public int QuestionId
        {
            get { return this._questionid; }
            set { this._questionid = value; }
        }

        public string Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public int UserId
        {
            get { return this._userid; }
            set { this._userid = value; }
        }

        public int Score
        {
            get { return this._score; }
            set { this._score = value; }
        }

        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }
    }
}