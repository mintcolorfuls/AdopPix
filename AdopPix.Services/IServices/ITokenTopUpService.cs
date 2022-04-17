using AdopPix.Services.ModelService;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    //Top up with credit or debit card with omise
    public interface ITokenTopUpService
    {
        Task<string> CreateCharge(int amount, string currency, string omiseToken); 
        Task<ChargeDetailModelService> GetChargeById(string chargeId);
    }
}
