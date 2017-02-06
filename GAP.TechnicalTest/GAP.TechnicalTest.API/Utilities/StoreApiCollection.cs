using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAP.TechnicalTest.API.Utilities
{
    public class StoreApiCollection
    {
        /// <summary>
        /// 
        /// </summary>
        public string Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Store> Stores { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Total_Elments { get; set; }
    }
}