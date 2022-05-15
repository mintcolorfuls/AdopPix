using AdopPix.Models;
using AdopPix.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class AuctionService : IAuctionService
    {
        public async Task CreateAuction(string auctionId, string userId, string title, int hourId, decimal openingPrice, decimal hotClose, string description)
        {
            var newAuction = new Auction()
            {
                AuctionId = auctionId,
                UserId = userId,
                Title = title,
                HourId = hourId,
                OpeningPrice = openingPrice,
                HotClose = hotClose,
                Description = description,
                Created = DateTime.Now,

            };


        }
    }
}
