using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class AuctionTag
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        public DateTime Created { get; set; }

        public Tag Tag { get; set; }
        public Auction Auction { get; set; }
    }
}
