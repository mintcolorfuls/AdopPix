using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class SocialMediaType
    {
        [Key]
        public int SocialId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        public List<SocialMedia> UserSocials { get; set; }
    }
}
