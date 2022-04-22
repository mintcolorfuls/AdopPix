using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class Auction
    {
        [Key]
        public string AuctionId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Title { get; set; }
        [ForeignKey("HourType")]
        public int HourId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal OpeningPrice { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal HotClose { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public HourType HourType { get; set; }
        public List<AuctionBid> AuctionBids { get; set; }
        public List<AuctionTag> AuctionTags { get; set; }
        public WinningBidder WinningBidder { get; set; }
        public List<AuctionNotification> AuctionNotifications { get; set; }
    }
}
