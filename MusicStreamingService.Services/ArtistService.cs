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
                Albums = 0,
                Followers = 0,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
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
                    Albums = entity.Albums,
                    Followers = entity.Followers,
                };
            }
        }
    }
}
