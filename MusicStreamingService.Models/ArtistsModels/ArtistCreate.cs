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
        public string Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Too many characters, please shorten.")]
        public string About { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
