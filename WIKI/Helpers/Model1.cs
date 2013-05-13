using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WIKI.Helpers
{
    public class Model1
    {


        public LuceneQData SampleData { get; set; }
        public IEnumerable<LuceneQData> AllSampleData { get; set; }
        public IEnumerable<LuceneQData> AllSearchIndexData { get; set; }
        public IEnumerable<LuceneQData> SampleSearchResults { get; set; }

        public string SearchQ { get; set; }

    }
}