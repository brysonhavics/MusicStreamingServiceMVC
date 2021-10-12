using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int AlbumsNumber { get; set; }
        public int Followers { get; set; }
        
        public virtual List<Song> Songs { get; set; }
        public virtual List<Album> Albums { get; set; }
        
    }
}
