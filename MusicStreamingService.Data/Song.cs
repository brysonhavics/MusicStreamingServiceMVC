using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan Length { get; set; }
    }
}
