using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumListItem
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
