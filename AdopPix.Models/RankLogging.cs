using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class RankLogging
    {
        [Key]
        public int rLogId { get; set; }
        [ForeignKey("UserProfile")]
        public string userId { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal amount { get; set; }
        public DateTime created { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
