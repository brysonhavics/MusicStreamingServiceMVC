﻿using MusicStreamingService.Data;
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

        public ActionResult Details(int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistById(id);

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}