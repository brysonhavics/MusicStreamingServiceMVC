using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AlbumCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArtistId { get; set; }
    }
}
