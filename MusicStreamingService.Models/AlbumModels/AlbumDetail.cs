using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumDetail
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Length")]
        public TimeSpan Length { get; set; }
    }
}
