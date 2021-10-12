using MusicStreamingService.Data;
using MusicStreamingService.Models.ArtistsModels;
using MusicStreamingService.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Services
{
    public class ArtistService
    {
        public bool CreateArtist(ArtistCreate model)
        {
            var entity = new Artist()
            {
                Name = model.Name,
                About = model.About,
                Birthday = model.Birthday,
                AlbumsNumber = 0,
                Followers = 0,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                    var query = ctx.Artists.Select(e => new ArtistListItem { About = e.About, Albums = e.AlbumsNumber, Birthday = e.Birthday, Followers = e.Followers, Name = e.Name, ArtistId = e.ArtistId});
                return query.ToArray();
            }
        }

        public List<Artist> GetArtistsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Artists.ToList();
            
            }
        }

        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(a => a.ArtistId == id);
                return new ArtistDetail()
                {
                    Name = entity.Name,
                    About = entity.About,
                    Birthday = entity.Birthday,
                    Albums = entity.AlbumsNumber,
                    Followers = entity.Followers,
                };
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(a => a.ArtistId == model.ArtistId);

                entity.Name = model.Name;
                entity.About = model.About;
                entity.Birthday = model.Birthday;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(a => a.ArtistId == artistId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
