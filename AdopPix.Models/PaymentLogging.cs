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
        [Column(TypeName = "nvarchar(256)")]
        public string Charge { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(65, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Currency { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Financing { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
    }
}
