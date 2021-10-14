using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }
        [Required]
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan Length { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
