using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.ArtistsModels
{
    public class ArtistDetail
    {
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime Birthday { get; set; }
        public int Albums { get; set; }
        public int Followers { get; set; }
    }
}
