using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class UserFollow
    {
        [Key]
        public int FollowId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string IsFollowing { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
    }
}
