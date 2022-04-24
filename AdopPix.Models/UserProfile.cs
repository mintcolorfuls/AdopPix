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
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string AvatarName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CoverName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Fname { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Lname { get; set; }
        [Column(TypeName = "nvarchar(150)")]
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
