using MusicStreamingService.Data;
using MusicStreamingService.Models.AlbumModels;
using MusicStreamingService.Models.SongModels;
using MusicStreamingService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Services
{
    public class AlbumService
    {
        //Create album, requires artist
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                Name = model.Name,
                ArtistId = model.ArtistId,
                ReleaseDate = model.ReleaseDate,
                Length = TimeSpan.Zero,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                ctx.Artists.Single(a => a.ArtistId == entity.ArtistId).AlbumsNumber += 1;
                return ctx.SaveChanges() == 2;
            }

        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Albums.Select(e => new AlbumListItem { AlbumId = e.AlbumId, Name = e.Name,
                    ArtistName = (ctx.Artists.FirstOrDefault(a => a.ArtistId == e.ArtistId).Name), ReleaseDate = e.ReleaseDate });
                return query.ToArray();
            }
        }
        //Used for select list
        public List<Album> GetAlbumsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Albums.ToList();
            }
        }

        public AlbumDetail GetAlbumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums.Single(a => a.AlbumId == id);
                return new AlbumDetail()
                {
                    AlbumId = entity.AlbumId,
                    ArtistName = (ctx.Artists.FirstOrDefault(a => a.ArtistId == entity.ArtistId).Name),
                    Name = entity.Name,
                    ReleaseDate = entity.ReleaseDate,
                    Length = entity.Length,
                    Image = entity.Image,
                };
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums.Single(a => a.AlbumId == model.AlbumId);
                entity.ArtistId = model.ArtistId;
                entity.Name = model.Name;
                entity.ReleaseDate = model.ReleaseDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums.Single(a => a.AlbumId == albumId);
                ctx.Artists.Single(a => a.ArtistId == entity.ArtistId).AlbumsNumber -= 1;
                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 2;
            }
        }
        //Get all songs on the album by the song's album id
        public IEnumerable<SongDetail> GetSongsOnAlbum(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums.Single(a => a.AlbumId == id);

                var query = entity.Songs.Select(s => new SongDetail { Name = s.Name, ArtistName = (ctx.Artists.FirstOrDefault
                    (a => a.ArtistId == s.ArtistId).Name), AlbumName = (ctx.Albums.FirstOrDefault(a => a.AlbumId == s.AlbumId).Name),
                    Length = s.Length
                });
                return query.ToArray();
            }
        }
        //Add string link to pic
        public bool AddAlbumCover(AddAlbumCover addAlbumCover)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Albums.Single(a => a.AlbumId == addAlbumCover.AlbumId);
                entity.Image = addAlbumCover.Image;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
