using System;

namespace AdopPix.Models.ViewModels
{
    public class AuctionViewModel
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public int HourId { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HotClose { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
