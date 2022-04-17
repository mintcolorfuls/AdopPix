using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class PointLogging
    {
        [Key]
        public int pLogId { get; set; }
        [ForeignKey("UserProfile")]
        public string userId { get; set; }
        public decimal amount { get; set; }
        public DateTime created { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
