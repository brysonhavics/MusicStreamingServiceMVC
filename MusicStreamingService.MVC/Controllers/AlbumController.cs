using MusicStreamingService.Data;
using MusicStreamingService.Models.AlbumModels;
using MusicStreamingService.Models.SongModels;
using MusicStreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingService.MVC.Controllers
{
    public class AlbumController : Controller
    {

        private AlbumService CreateAlbumService()
        {
            var albumService = new AlbumService();
            return albumService;
        }
        // GET: Album
        public ActionResult Index()
        {
            var service = new AlbumService();
            var model = service.GetAlbums();
            return View(model);
        }

        //Get: Create
        //Album/Create
        public ActionResult Create()
        {
            ViewBag.Title = "New Album";

            List<Artist> Artists = new ArtistService().GetArtistsList();
            var selectList = from a in Artists
                        select new SelectListItem()
                        {
                            Value = a.ArtistId.ToString(),
                            Text = a.Name
                        };
            ViewBag.ArtistId = selectList.ToList();

            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateAlbumService();
            if (service.CreateAlbum(model))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get: Details

        public ActionResult Details(int id)
        {
            var service = CreateAlbumService();
            var model = service.GetAlbumById(id);

            return View(model);
        }

        //Get: Edit

        public ActionResult Edit()
        {
            return View();
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumEdit model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateAlbumService();
                service.UpdateAlbum(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Get: Delete
        public ActionResult Delete(int id)
        {
            var service = CreateAlbumService();
            var model = service.GetAlbumById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAlbum(int id)
        {
            var service = CreateAlbumService();
            service.DeleteAlbum(id);
            TempData["SaveResult"] = "The album was deleted";
            return RedirectToAction("Index");
        }

        [Route("AlbumSongs/{id:int}")]
        public ActionResult AlbumSongs(int id)
        {
            var service = CreateAlbumService();
            var model = service.GetSongsOnAlbum(id);
            //ViewBag.AlbumName = model[0].
            return View(model);
        }

    }
}