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
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Length")]
        public TimeSpan Length { get; set; }
    }
}
