using MusicStreamingService.Data;
using MusicStreamingService.Models.SongModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamingService.Models
{
    public class PlaylistCreate
    {
        public int PlaylistId { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Is it private")]
        public bool Private { get; set; }
    }

    public class PlaylistView
    {
        public int PlaylistId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Likes")]
        public int Likes { get; set; }
        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }
        [Display(Name = "Length")]
        public TimeSpan Length { get; set; }
        public virtual List<Song> Songs { get; set; }
    }

    public class PlaylistAddSong
    {
        public int PlaylistId { get; set; }
        public Guid UserId { get; set; }
        public int SongId { get; set; }
    }
}
