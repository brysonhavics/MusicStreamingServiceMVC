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
            if (model.Image == null)
            {
                model.Image = "No Image";
            }
            return View(model);
        }

        //Get: Edit
        public ActionResult Edit(int id)
        {
            List<Artist> Artists = new ArtistService().GetArtistsList();
            var artistList = from a in Artists
                             select new SelectListItem()
                             {
                                 Value = a.ArtistId.ToString(),
                                 Text = a.Name
                             };
            ViewBag.ArtistId = artistList.ToList();
            var service = CreateAlbumService();
            var detail = service.GetAlbumById(id);
            var model = new AlbumEdit()
            {
                AlbumId = detail.AlbumId,
                ArtistId = detail.ArtistId,
                Name = detail.Name,
                ReleaseDate = detail.ReleaseDate,
            };
            ViewBag.Name = detail.Name;
            return View(model);
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

        //Post: Delete
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

        //Get: Songs on Album
        [Route("AlbumSongs/{id:int}")]
        public ActionResult AlbumSongs(int id)
        {
            var service = CreateAlbumService();
            var model = service.GetSongsOnAlbum(id);
            ViewBag.Name = service.GetAlbumById(id).Name;
            return View(model);
        }
        //Get: Adding album cover
        [Route("AddAlbumCover/{id:int}")]
        public ActionResult AddAlbumCover(int id)
        {
            var service = CreateAlbumService();
            var details = service.GetAlbumById(id);
            var model = new AddAlbumCover()
            {
                Name = details.Name,
                AlbumId = details.AlbumId,
            };
            return View(model);
        }

        //Post: Add album cover
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAlbumCover(AddAlbumCover addAlbumCover)
        {
            if (!ModelState.IsValid)
            {
                return View(addAlbumCover);
            }
            var service = CreateAlbumService();
            if (service.AddAlbumCover(addAlbumCover))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}