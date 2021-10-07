using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
    }
}
