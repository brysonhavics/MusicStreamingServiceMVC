using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.ArtistsModels
{
    public class ArtistCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Too many characters, please shorten.")]
        [Display(Name = "About Artist")]
        public string About { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // added for date picker
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }
}
