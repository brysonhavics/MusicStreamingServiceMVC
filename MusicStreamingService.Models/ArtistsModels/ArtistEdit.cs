using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.ArtistsModels
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime Birthday {get; set; }
    }
}
