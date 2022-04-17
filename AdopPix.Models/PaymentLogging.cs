using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdopPix.Models
{
    public class PaymentLogging
    {
        [Key]
        public int PLogId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Charge { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Brand { get; set; }
        public string Financing { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
    }
}
