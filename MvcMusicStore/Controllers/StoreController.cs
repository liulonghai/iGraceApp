using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();

        ///
        /// GET: /Index/
        ///
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        /// <summary>
        /// 浏览一个类型所包含的所有唱片
        /// </summary>
        /// <returns></returns>
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name==genre);
            return View(genreModel);
        }

        /// <summary>
        /// 浏览单张唱片的详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(int ID)
        {
            var album = storeDB.Albums.Find(ID);
            return View(album);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            
            return PartialView(genres);
        }

    }
}
