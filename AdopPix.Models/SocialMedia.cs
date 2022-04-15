using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class SocialMedia
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("SocialMedia")]
        public string SocialId { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public SocialMediaType SocialMediaType { get; set; }
    }
}
