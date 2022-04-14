using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdopPix.Models
{
    public class SocialMediaType
    {
        [Key]
        public int SocialId { get; set; }
        public string Title { get; set; }

        public List<SocialMedia> UserSocials { get; set; }
    }
}
