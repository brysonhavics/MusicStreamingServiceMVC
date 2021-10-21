using MusicStreamingService.Data;
using MusicStreamingService.Models;
using MusicStreamingService.Models.SongModels;
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
            var service = CreatePlaylistService();
            var detail = service.GetPlaylist(id);
            var model = new PlaylistAddSong
            {
                PlaylistId = detail.PlaylistId,
            };
            List<Song> Songs = new SongService().GetSongsList().ToList(); ;
            var songsList = from a in Songs
                             select new SelectListItem()
                             {
                                 Value = a.SongId.ToString(),
                                 Text = a.Name
                             };
            
            ViewBag.SongId = songsList.ToList();

            return View(model);
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
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Playlist/Delete/5
        public ActionResult Delete(int id)
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylist(id);
            return View(model);
        }

        // POST: Playlist/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlaylist(int id)
        {
            var service = CreatePlaylistService();
            service.DeletePlaylist(id);
            TempData["SaveResult"] = "The playlist was deleted";
            return RedirectToAction("Index");
        }

        //Get: View Songs
        public ActionResult PlaylistSongs(int id)
        {
            var service = CreatePlaylistService();
            var model = service.GetSongsOnPlaylist(id);
            return View(model);
        }

    }
}
