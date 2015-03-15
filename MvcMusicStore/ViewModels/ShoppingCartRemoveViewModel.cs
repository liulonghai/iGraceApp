using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class ShoppingCartRemoveViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal CartTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CartCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DeleteId { get; set; }
    }
}