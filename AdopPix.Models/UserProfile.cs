using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Gender { get; set; }
        public string AvaterName { get; set; }
        public string CoverName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal Money { get; set; }
        public DateTime BirthDate { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal Point { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal Rank { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public List<PointLogging> PointLogging { get; set; }
        public List<RankLogging> RankLogging { get; set; }
    }
}
