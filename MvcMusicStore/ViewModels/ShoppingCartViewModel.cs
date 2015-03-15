using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;

namespace MvcMusicStore.Models
{
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// 购物车项列表
        /// </summary>
        public List<Cart> CartItems { get; set; }

        /// <summary>
        /// 购物车中物品总价
        /// </summary>
        public decimal CartTotal { get; set; }

    }
}