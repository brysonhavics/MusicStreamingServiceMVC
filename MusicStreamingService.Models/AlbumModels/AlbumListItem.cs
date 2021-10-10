using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumListItem
    {
        public int AlbumId { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
        [Display(Name = "Released")]
        public DateTime ReleaseDate { get; set; }
    }
}
