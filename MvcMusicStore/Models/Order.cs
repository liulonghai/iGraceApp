using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 订单类
    /// </summary>
    [Bind(Exclude = "OrderId")]
    public class Order
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        /// <summary>
        /// 名字必填
        /// </summary>
        [Required(ErrorMessage = "First Name is Required.")]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// 姓氏必填
        /// </summary>
        [Required(ErrorMessage = "Last Name is Required.")]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// 具体地址，例如街道，楼层
        /// </summary>
        [Required(ErrorMessage = "Address is Required.")]
        [StringLength(50)]
        public string Address { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Required(ErrorMessage = "City is Required.")]
        [StringLength(50)]
        public string City { get; set; }

        /// <summary>
        /// 所在州，或省
        /// </summary>
        [Required(ErrorMessage = "State is Required.")]
        [StringLength(50)]
        [DisplayName("省")]
        public string State { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [Required(ErrorMessage = "Country is Required.")]
        [StringLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [Required(ErrorMessage = "Postal Code is Required.")]
        [StringLength(10)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "Email is Required.")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        /// <summary>
        /// 订单生成时间
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
