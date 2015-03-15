using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        //数据库的访问上下文
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //促销码
        const string PromoCode = "FREE";

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Checkout/      
        [HttpGet]
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {                   
            //订单是一个对象
            var order = new Order();

            //通过模型绑定，将请求参数绑定到模型对象上
            TryUpdateModel(order);

            try
            {
                //检查促销码填写是否正确
                if (!string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase))
                {
                    return View(order);
                }
                else
                {
                    //生成订单
                    order.UserName = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //保存订单，目的是生成订单编号，通过订单编号，保存订单明细
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    //保存订单明细
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });

                }

            }
            catch (Exception e)
            {
                return View(order);
            }
        }

        //完成订单之后的提示
        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.Orders.Any(o => o.OrderId == id && o.UserName == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                //"Error" 串，视图名称
                return View("Error");
            }
        }

    }
}
