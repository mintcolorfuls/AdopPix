using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class Notification
    {
        [Key]
        public int NotiId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Description { get; set; }
        public string RedirectToUrl { get; set; }
        public bool isOpen { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
    }
}
