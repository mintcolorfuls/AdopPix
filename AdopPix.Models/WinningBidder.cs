using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class WinningBidder
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        public double amount { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public Auction Auction { get; set; }
    }
}
