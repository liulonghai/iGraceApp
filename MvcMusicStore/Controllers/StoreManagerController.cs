using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    [Authorize(Roles="Administrator")]
    public class StoreManagerController : Controller
    {
        MvcMusicStore.Models.MusicStoreEntities storeDB = new Models.MusicStoreEntities();
        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist");
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres,"GenreId","Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(MvcMusicStore.Models.Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    storeDB.Albums.Add(album);
                    storeDB.SaveChanges();
                    return RedirectToAction("Index");
                    //ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
                    //ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");

                    //return View(album);
                }


            }
            catch
            {
                return View();
            }
            return View();
        }

        //获取编辑前的数据
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //提交编辑后的数据
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
                if (this.TryUpdateModel<MvcMusicStore.Models.Album>(album))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //获取待删除的数据
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //提交删除的数据
        // POST: /StoreManager/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MvcMusicStore.Models.Album album = storeDB.Albums.Find(id);
                storeDB.Albums.Remove(album);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
