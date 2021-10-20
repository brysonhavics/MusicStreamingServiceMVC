using MusicStreamingService.Data;
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

        public IEnumerable<PlaylistListItem> GetPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Playlists.Select(p => new PlaylistListItem
                {
                    Name = p.Name,
                    Description = p.Description,
                    Length = p.Length,
                    PlaylistId = p.PlaylistId,
                });
                return query.ToArray();
            }
        }

        public PlaylistView GetPlaylist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists.Single(p => p.PlaylistId == id);

                return new PlaylistView()
                {
                    PlaylistId = entity.PlaylistId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Likes = entity.Likes,
                    Created = entity.Created,
                    Length = entity.Length,
                    Songs = entity.Songs,
                };
            }
        }

        public bool AddSong(PlaylistAddSong model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Playlists.Single(p => p.PlaylistId == model.PlaylistId);
                entity.Songs.Add(ctx.Songs.Single(s => s.SongId == model.SongId));



                return ctx.SaveChanges() == 1;
            }
        }
    }
}
