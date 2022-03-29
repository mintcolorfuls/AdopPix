using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdopPix.Models
{
    public class SocialMedias
    {
        [Key]
        public int SocialId { get; set; }
        public string Title { get; set; }

        public List<UserSocial> UserSocials { get; set; }
    }
}
