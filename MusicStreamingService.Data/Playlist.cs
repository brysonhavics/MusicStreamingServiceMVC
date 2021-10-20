using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Data
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        //TODO
        //public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public DateTime Created { get; set; }
        public TimeSpan Length { get; set; }
        public bool Private { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
