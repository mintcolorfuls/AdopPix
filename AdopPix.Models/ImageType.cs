using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class ImageType
    {
        [Key]
        public int ImageTypeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        public List<AuctionImage> AuctionImages { get; set; }
    }
}
