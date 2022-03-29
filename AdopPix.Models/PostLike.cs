using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class PostLike
    {
        [Key]
        public int LikeId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Post")]
        public string PostId { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}
