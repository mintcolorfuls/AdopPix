using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class SocialMedia
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("SocialMediaType")]
        public int SocialId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public SocialMediaType SocialMediaType { get; set; }
    }
}
