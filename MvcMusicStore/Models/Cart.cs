using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 购物车：允许非注册用户向购物车放商品，也允许注册用户向购物车放商品
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// 记录Id,一行数据
        /// </summary>
        [Key]
        public int RecordId{get;set;}

        /// <summary>
        /// 购物车Id
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 专辑Id
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 购物车创建时间
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 虚拟类型会使EF使用懒加载
        /// </summary>
        public virtual Album album { get; set; }
    }
}