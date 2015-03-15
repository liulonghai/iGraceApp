using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 音乐专辑
    /// </summary>
    [Bind(Exclude="AlbumId")]
    public class Album
    {
        /// <summary>
        /// 专辑ID
        /// </summary>
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        /// <summary>
        /// 流派ID
        /// </summary>
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        /// <summary>
        /// 艺术家ID
        /// </summary>
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        /// <summary>
        /// 专辑名
        /// </summary>
        [Required(ErrorMessage="An album title is required!")]
        [StringLength(160)]
        public string Title { get; set; }

        /// <summary>
        /// 专辑价格
        /// </summary>
       [Required(ErrorMessage="Price is required!")]
        [Range(0.1,100.00,ErrorMessage="Price is must between 0.01 and 100.00.")]
        public decimal Price { get; set; }

        /// <summary>
        /// 专辑链接
        /// </summary>
        [DisplayName("Album Art Url")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        public virtual Artist Artist { get; set; }

        /// <summary>
        /// 唱片所属的流派
        /// </summary>
        public virtual Genre Genre { get; set; }


        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}