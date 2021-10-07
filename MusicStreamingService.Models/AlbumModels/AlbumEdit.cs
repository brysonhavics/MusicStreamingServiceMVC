using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumEdit
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
