using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIKI.Helpers
{
    public class ATags
    {

        int _tagid;
        //string _tag;
        string _name;

        public int TagId
        {
            get { return this._tagid; }
            set { this._tagid = value; }
        }

        //public string Tag
        //{
        //    get { return this._tag; }
        //    set { this._tag = value; }
        //}

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

    }
}