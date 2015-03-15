using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 依赖此类生成数据库：名称必须与数据库连接串的名称一致
    /// 这个类将反映 Entity Framework 数据库的上下文，用来处理创建，读取，更新和删除的操作
    /// </summary>
    public class MusicStoreEntities : DbContext
    {
        /// <summary>
        /// 专辑
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// 流派
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        public DbSet<Artist> Artists { get; set; }

        /// <summary>
        /// 购物车
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}