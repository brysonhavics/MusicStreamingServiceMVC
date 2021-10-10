﻿using MusicStreamingService.Models.AlbumModels;
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
    }
}