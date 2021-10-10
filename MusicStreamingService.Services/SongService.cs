using MusicStreamingService.Data;
using MusicStreamingService.Models.SongModels;
using MusicStreamingService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Services
{
    public class SongService
    {
        public bool CreateSong(SongCreate model)
        {
            var entity = new Song()
            {
                AlbumId = model.AlbumId,
                ArtistId = model.ArtistId,
                Name = model.Name,
                Length = model.Length,
            };

            using (var ctx = new ApplicationDbContext())
            {
                //entity.ReleaseDate = entity.Album.ReleaseDate;
                entity.ReleaseDate = ctx.Albums.Where(a => a.AlbumId == entity.AlbumId).FirstOrDefault().ReleaseDate;
                //entity.Album.Length += entity.Length;
                ctx.Albums.Where(a => a.AlbumId == entity.AlbumId).FirstOrDefault().Length += entity.Length;
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Songs.Select(e => new SongListItem { SongId = e.SongId, AlbumName = e.Album.Name, ArtistName = e.Artist.Name, Name = e.Name});
                return query.ToArray();
            }
        }

        public SongDetail GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs.Single(s => s.SongId == id);
                return new SongDetail()
                {
                    AlbumName = entity.Album.Name,
                    ArtistName = entity.Artist.Name,
                    Name = entity.Name,
                    ReleaseDate = entity.ReleaseDate,
                    Length = entity.Length,
                };
            }
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Songs.Single(s => s.SongId == model.SongId);

                entity.AlbumId = model.AlbumId;
                entity.ArtistId = model.ArtistId;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
