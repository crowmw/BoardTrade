using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoardTrade.Data.Models
{
    public class BoardGame
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        [Required]
        public int MinPlayers { get; set; }
        [Required]
        public int MaxPlayers { get; set; }
        public int PlayingTime { get; set; }
        public bool IsExpansion { get; set; }
        public int YearPublished { get; set; }
        public float Rating { get; set; }
        public float AverageRating { get; set; }
        public int Rank { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public DateTime TimeOfModification { get; set; }
    }
}
