using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        /// <summary>
        /// 非Action方法，不能直接在地址栏中访问
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [NonAction]
        private List<Album> GetTopSellingAlbums(int count)
        {
            return storeDB.Albums.OrderByDescending(
                a => a.OrderDetails.Count()).Take(count).ToList();
        }

    }
}
