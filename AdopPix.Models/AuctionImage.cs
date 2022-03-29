using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class AuctionImage
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey("ImageType")]
        public int ImageTypeId { get; set; }

        public Auction Auction { get; set; }
        public ImageType ImageType { get; set; }
    }
}
