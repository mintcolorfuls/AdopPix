using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class AuctionImage
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string ImageId { get; set; }
        [ForeignKey("Auction")]
        public string AuctionId { get; set; }
        [ForeignKey("ImageType")]
        public int ImageTypeId { get; set; }
        public DateTime Created { get; set; }

        public Auction Auction { get; set; }
        public ImageType ImageType { get; set; }
    }
}
