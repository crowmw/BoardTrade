using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoardTrade.Data.Models
{
    public class UserBoardGame
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual BoardGame BoardGame { get; set; }
        //public virtual User User { get; set; }
        public Condition Condition { get; set; }
        //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions
        public string Language { get; set; }
        public bool Unwanted { get; set; }
        public bool Wanted { get; set; }
        public bool ForSale { get; set; }
        public float Price { get; set; }
        public bool ForExchange { get; set; }
        public bool Shipping { get; set; }
        public float ShippingPrice { get; set; }
        public string Note { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public DateTime TimeOfModification { get; set; }
    }
}
