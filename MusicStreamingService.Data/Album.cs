using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Data
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
    }
}
