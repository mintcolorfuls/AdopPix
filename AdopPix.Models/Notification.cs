using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class Notification
    {
        [Key]
        public int NotiId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string RedirectToUrl { get; set; }
        public bool isOpen { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
    }
}
