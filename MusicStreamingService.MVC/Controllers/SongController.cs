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

        // GET: Song/Details/
        public ActionResult Details(int id)
        {
            var service = CreateSongService();
            var model = service.GetSongById(id);
            return View(model);
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

        // GET: Song/Edit
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Song/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SongEdit song)
        {
            if (ModelState.IsValid)
            {
                var service = CreateSongService();
                service.UpdateSong(song);
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Song/Delete/
        public ActionResult Delete(int id)
        {
            var service = CreateSongService();
            var model = service.GetSongById(id);
            return View(model);
        }

        // POST: Song/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSong(int id)
        {
            var service = CreateSongService();
            service.DeleteSong(id);
            TempData["SaveResult"] = "The song was deleted";
            return RedirectToAction("Index");
        }
    }
}
