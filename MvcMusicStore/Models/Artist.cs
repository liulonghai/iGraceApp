using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 艺术家类
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// 艺术家Id
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// 艺术家名字
        /// </summary>
        public string Name { get; set; }
    }
}