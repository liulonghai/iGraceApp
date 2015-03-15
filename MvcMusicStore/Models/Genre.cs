using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 音乐流派
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// 流派Id
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// 流派名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 专辑列表：一个流派可以包含多个专辑
        /// </summary>
        public List<Album> Albums { get; set; }
    }
}