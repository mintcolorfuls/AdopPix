using AdopPix.Services.IServices;
using AdopPix.Services.ModelService;
using Microsoft.Extensions.Configuration;
using Omise;
using Omise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class TokenTopUpService : ITokenTopUpService
    {
        private readonly IConfiguration configuration;
        Client omise;
        public TokenTopUpService(IConfiguration configuration)
        {
            omise = new Client(this.configuration["Omise_PublicKey"], this.configuration["Omise_SecretKey"]);
            this.configuration = configuration;
        }
        public async Task<string> CreateCharge(int amount, string currency, string omiseToken)
        {
            var charge = await omise.Charges.Create(new CreateChargeRequest
            {
                Amount = amount * 100,
                Currency = currency,
                Card = omiseToken
            });
            return charge.Id;
        }

        public async Task<ChargeDetailModelService> GetChargeById(string chargeId)
        {
            var charge = await omise.Charges.Get(chargeId);
            ChargeDetailModelService chargeDetailModelService = new ChargeDetailModelService
            {
                Charge = charge.Id,
                Name = charge.Card.Name,
                Amount = charge.Amount / 100,
                Currency = charge.Currency,
                Brand = charge.Card.Brand,
                Financing = charge.Card.Financing
            };
            return chargeDetailModelService;
        }
    }
}
