using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class Post
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string PostId { get; set; }
        [Column(TypeName = "nvarchar(160)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(160)")]
        public string Description { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<PostComment> PostComments { get; set; }
        public List<PostView> PostViews { get; set; }
        public List<PostImage> PostImages { get; set; }
        public List<PostTag> PostTags { get; set; }
    }

    
}
