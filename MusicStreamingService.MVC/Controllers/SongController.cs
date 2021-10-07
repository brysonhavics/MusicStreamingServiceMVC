using MusicStreamingService.Models.ArtistsModels;
using MusicStreamingService.Models.SongModels;
using MusicStreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingService.MVC.Controllers
{
    public class SongController : Controller
    {
        private SongService CreateSongService()
        {
            var songService = new SongService();
            return songService;
        }

        // GET: Song
        public ActionResult Index()
        {
            var service = CreateSongService();
            var model = service.GetSongs();
            return View(model);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateSongService();
            if (service.CreateSong(model))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
