using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 订单详情
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// 订单详情表主键
        /// </summary>
        public int OrderDetailId { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 专辑Id
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 专辑
        /// </summary>
        public virtual Album album { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order order { get; set; }
    }
}