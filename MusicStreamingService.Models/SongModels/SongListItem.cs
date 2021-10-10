using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.SongModels
{
    public class SongListItem
    {
        public int SongId { get; set; }
        [Display(Name ="Album")]
        public string AlbumName { get; set; }
        [Display(Name ="Artist")]
        public string ArtistName { get; set; }
        [Display(Name = "Song")]
        public string Name { get; set; }
    }
}
