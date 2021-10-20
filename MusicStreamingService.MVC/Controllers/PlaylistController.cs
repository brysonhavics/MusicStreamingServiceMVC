using MusicStreamingService.Data;
using MusicStreamingService.Models;
using MusicStreamingService.MVC.Models;
using MusicStreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingService.MVC.Controllers
{
    public class PlaylistController : Controller
    {
        private PlaylistService CreatePlaylistService()
        {
            return new PlaylistService();
        }

        public ActionResult Index()
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylists();
            return View(model);
        }

        // GET: Playlist/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Playlist/Create
        [HttpPost]
        public ActionResult Create(PlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePlaylistService();
            if (service.CreatePlaylist(model))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get: Playlist Detail
        public ActionResult Details(int id)
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylist(id);
            return View(model);
        }

        // GET: Playlist/Edit/5
        public ActionResult AddSong(int id)
        {
            List<Song> Songs = new SongService().GetSongsList().ToList(); ;
            var songsList = from a in Songs
                             select new SelectListItem()
                             {
                                 Value = a.SongId.ToString(),
                                 Text = a.Name
                             };
            
            ViewBag.SongId = songsList.ToList();

            return View();
        }

        // POST: Playlist/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSong(PlaylistAddSong model)
        {
            if (ModelState.IsValid)
            {
                var service = CreatePlaylistService();
                service.AddSong(model);
                return RedirectToAction($"Details/{model.PlaylistId}");
            }
            return View(model);
        }

        // GET: Playlist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlist/Delete/5
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
