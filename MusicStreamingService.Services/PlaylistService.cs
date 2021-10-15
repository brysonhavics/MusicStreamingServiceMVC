﻿using MusicStreamingService.Data;
using MusicStreamingService.Models;
using MusicStreamingService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Services
{
    public class PlaylistService
    {
        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity = new Playlist()
            {
                Name = model.Name,
                Description = model.Description,
                Likes = 0,
                Created = DateTime.Now,
                Length = TimeSpan.Zero,
                Private = model.Private,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public PlaylistView GetPlaylist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists.Single(p => p.PlaylistId == id);

                return new PlaylistView()
                {
                    Name = entity.Name,
                    Description = entity.Description,
                    Likes = entity.Likes,
                    Created = entity.Created,
                    Length = entity.Length,
                    Songs = entity.Songs,
                };
            }
        }
    }
}