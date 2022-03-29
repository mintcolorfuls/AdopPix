using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class UserSocial
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("SocialMedia")]
        public string SocialId { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public SocialMedias SocialMedias { get; set; }
    }
}
