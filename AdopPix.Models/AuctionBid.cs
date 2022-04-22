using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace AdopPix.Models
{
    public class AuctionBid
    {
        [Key]
        public int BidId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public Auction Auction { get; set; }
    }
}
