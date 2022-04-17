using AdopPix.Services.ModelService;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    //Top up with credit or debit card with omise
    public interface ITokenPaymentService
    {
        Task<string> CreateCharge(decimal amount, string currency, string omiseToken); 
        Task<ChargeDetailModelService> GetChargeById(string chargeId);
    }
}
