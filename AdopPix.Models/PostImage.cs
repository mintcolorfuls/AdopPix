using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class PostImage
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string ImageId { get; set; }
        [ForeignKey("Post")]
        public string PostId { get; set; }
        public DateTime Created { get; set; }

        public Post Post { get; set; }
    }
}
