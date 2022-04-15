using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class PostTag
    {
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("Post")]
        public string PostId { get; set; }
        public DateTime Created { get; set; }

        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}
