using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdopPix.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public List<AuctionTag> AuctionTags { get; set; }
    }
}
