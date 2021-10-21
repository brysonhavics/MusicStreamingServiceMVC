using MusicStreamingService.Data;
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

        // GET: Index
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
            ViewBag.Title = "New Song";

            List<Artist> Artists = new ArtistService().GetArtistsList();
            var artistList = from a in Artists
                             select new SelectListItem()
                             {
                                 Value = a.ArtistId.ToString(),
                                 Text = a.Name
                             };
            ViewBag.ArtistId = artistList.ToList();
            List<Album> Albums = new AlbumService().GetAlbumsList();
            var albumList = from b in Albums
                            select new SelectListItem()
                            {
                                Value = b.AlbumId.ToString(),
                                Text = b.Name
                            };
            ViewBag.AlbumId = albumList.ToList();
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
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Song";
            var service = CreateSongService();
            var detail = service.GetSongById(id);
            var model = new SongEdit()
            {
                SongId = detail.SongId,
                Name = detail.Name,
            };
            List<Artist> Artists = new ArtistService().GetArtistsList();
            var artistList = from a in Artists
                             select new SelectListItem()
                             {
                                 Value = a.ArtistId.ToString(),
                                 Text = a.Name
                             };
            ViewBag.ArtistId = artistList.ToList();
            List<Album> Albums = new AlbumService().GetAlbumsList();
            var albumList = from b in Albums
                            select new SelectListItem()
                            {
                                Value = b.AlbumId.ToString(),
                                Text = b.Name
                            };
            ViewBag.AlbumId = albumList.ToList();
            ViewBag.Name = CreateSongService().GetSongById(id).Name;
            return View(model);
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
