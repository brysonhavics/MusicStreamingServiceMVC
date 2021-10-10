using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumEdit
    {
        public int AlbumId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Artist Id")]
        public int ArtistId { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
}
