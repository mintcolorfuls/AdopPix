using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        public DateTime Created { get; set; }

        public List<AuctionTag> AuctionTags { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
}
