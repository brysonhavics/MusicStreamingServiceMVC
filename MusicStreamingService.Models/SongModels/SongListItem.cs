﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models.SongModels
{
    public class SongListItem
    {
        [Key]
        public int SongId { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string Name { get; set; }
    }
}
