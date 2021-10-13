using MusicStreamingService.Data;
using MusicStreamingService.Models.ArtistsModels;
using MusicStreamingService.MVC.Models;
using MusicStreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStreamingService.MVC.Controllers
{
    public class ArtistController : Controller
    {

        private ArtistService CreateArtistService()
        {
            var artistService = new ArtistService();
            return artistService;
        }

        // GET: Artist
        public ActionResult Index()
        {
            var service = new ArtistService();
            var model = service.GetArtists();
            return View(model);
        }

        //Get: Create
        //Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate artistModel)
        {
            if (!ModelState.IsValid)
            {
                return View(artistModel);
            }
            var service = CreateArtistService();
            if (service.CreateArtist(artistModel))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get: Details

        public ActionResult Details(int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistById(id);
            
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
        public ActionResult Edit(ArtistEdit artist)
        {
            if (ModelState.IsValid)
            {
                var service = CreateArtistService();
                service.UpdateArtist(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //Get: Delete
        public ActionResult Delete(int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistById(id);
            return View(model);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtist(int id)
        {
            var service = CreateArtistService();
            service.DeleteArtist(id);
            TempData["SaveResult"] = "The artist was deleted";
            return RedirectToAction("Index");
        }
        
        [Route("ArtistAlbums/{id:int}")]
        public ActionResult ArtistAlbums(int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistAlbums(id);
            ViewBag.Artist = service.GetArtistById(id).Name;
            return View(model);
        }
    }
}