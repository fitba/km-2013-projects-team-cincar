﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIKI.Helpers
{
    public class QATag
    {

        int _tagid;
        string _tag;

        public int TagId
        {
            get { return this._tagid; }
            set { this._tagid = value; }
        }

        public string Tag
        {
            get { return this._tag; }
            set { this._tag = value; }
        }
    }
}