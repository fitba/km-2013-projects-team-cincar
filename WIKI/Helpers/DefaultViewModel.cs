using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WIKI.Helpers
{
   
        public class DefaultViewModel
        {

           
	        
            public LuceneData SampleData { get; set; }
            public IEnumerable<LuceneData> AllSampleData { get; set; }         
            public IEnumerable<LuceneData> AllSearchIndexData { get; set; }
            public IEnumerable<LuceneData> SampleSearchResults { get; set; }
          
            public string SearchTerm { get; set; }
          

     
        }
    }
