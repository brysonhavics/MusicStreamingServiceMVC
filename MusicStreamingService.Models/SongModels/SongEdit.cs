using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.SongModels
{
    public class SongEdit
    {
        public int SongId { get; set; }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        [Display(Name ="Name")]
        public string Name { get; set; }
    }
}
