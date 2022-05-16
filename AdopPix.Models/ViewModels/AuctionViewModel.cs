using Microsoft.AspNetCore.Http;
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


        public string AuctionImage { get; set; }
        public IFormFile AuctionFile { get; set; }

        public string ImageId { get; set; }
        public string AuctionId { get; set; }
        public int ImageTypeId { get; set; }


    }
}

