using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }


        public ActionResult AddToCart(int id)
        {
            //retrieve the album from the database
            var addedAlbum = storeDB.Albums.Single(album => album.AlbumId == id);

            //add it to shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedAlbum);

            //go back to the main page for more shopping
            return RedirectToAction("Index");

        }

        /// <summary>
        /// AJAX:/ShoppingCart/RemoveFromCart/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            //remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var albumName = storeDB.Carts.Single(album => album.RecordId == id).album.Title;

            //remove from the cart
            int itemCount = cart.RemoveFromCart(id);

            //display the confirmation message
            var results = new ShoppingCartRemoveViewModel()
            {
                Message = Server.HtmlEncode(albumName) + " has been removed from your shopping cart.",
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                CartTotal = cart.GetTotal(),
                DeleteId = id
            };

            return Json(results);
        }

        ///ChildActionOnly的目的主要就是让这个Action不通过直接在地址栏输入地址来访问，而是需要通过RenderAction来调用它
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}
