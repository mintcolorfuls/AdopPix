using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class AuctionNotification
    {
        [Key]
        public int AucNotiId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        public string Description { get; set; }
        public bool isOpen { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public Auction Auction { get; set; }
    }
}
