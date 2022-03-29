using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdopPix.Models
{
    public class HourType
    {
        [Key]
        public int HourId { get; set; }
        public int Hour { get; set; }

        public List<Auction> Auctions { get; set; }
    }
}
