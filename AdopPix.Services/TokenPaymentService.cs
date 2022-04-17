using AdopPix.Services.IServices;
using AdopPix.Services.ModelService;
using Microsoft.Extensions.Configuration;
using Omise;
using Omise.Models;
using System;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class TokenPaymentService : ITokenPaymentService
    {
        private readonly IConfiguration configuration;
        public TokenPaymentService(IConfiguration configuration)
        {
            
            this.configuration = configuration;
        }
        public async Task<string> CreateCharge(decimal amount, string currency, string omiseToken)
        {
            Client omise = new Client(configuration["Omise_PublicKey"], configuration["Omise_SecretKey"]);
            var charge = await omise.Charges.Create(new CreateChargeRequest
            {
                Amount = (int)(amount * 100),
                Currency = currency,
                Card = omiseToken
            });
            return charge.Id;
        }

        public async Task<ChargeDetailModelService> GetChargeById(string chargeId)
        {
            Client omise = new Client(configuration["Omise_PublicKey"], configuration["Omise_SecretKey"]);
            var charge = await omise.Charges.Get(chargeId);

            ChargeDetailModelService chargeDetailModelService = new ChargeDetailModelService
            {
                Charge = charge.Id,
                Name = charge.Card.Name,
                Amount = Convert.ToDecimal(charge.Amount / 100.00),
                Currency = charge.Currency,
                Brand = charge.Card.Brand,
                Financing = charge.Card.Financing
            };
            return chargeDetailModelService;
        }
    }
}
