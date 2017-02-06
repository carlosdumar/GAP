using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.TechnicalTest.API.Utilities
{
    public class ArticleApiCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public string Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Article> Article { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Article> Articles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Error_Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Error_Msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Elments { get; set; }
    }
}