using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.SongModels
{
    public class SongCreate
    {
        [Required]
        [Display(Name = "Album Name")]
        public int AlbumId { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public int ArtistId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Length")]
        public TimeSpan Length { get; set; }
    }
}
