using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.AlbumModels
{
    public class AddAlbumCover
    {
        public int AlbumId { get; set; }
        [Display(Name = "Image URL")]
        public string Image { get; set; }
        [Display(Name = "Album Title")]
        public string Name { get; set; }
    }
}
