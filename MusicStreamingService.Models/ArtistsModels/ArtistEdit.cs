using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.ArtistsModels
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "About Artist")]
        public string About { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // added for date picker
        [Display(Name = "Birthday")]
        public DateTime Birthday {get; set; }
    }
}
