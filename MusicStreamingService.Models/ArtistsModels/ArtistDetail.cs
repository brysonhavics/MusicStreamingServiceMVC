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
        public int ArtistId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "About Artist")]
        public string About { get; set; }
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [Display(Name = "# of Albums")]
        public int Albums { get; set; }
        [Display(Name = "# of Followers")]
        public int Followers { get; set; }
    }
}
