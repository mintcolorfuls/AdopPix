using System;
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
        public string coverName { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int money { get; set; }
        public DateTime birthDate { get; set; }
        public int point { get; set; }
        public int rank { get; set; }
        public DateTime created { get; set; }

        public User User { get; set; }
    }
}
