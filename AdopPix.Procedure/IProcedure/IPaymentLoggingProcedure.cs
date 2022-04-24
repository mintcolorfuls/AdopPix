using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IPaymentLoggingProcedure
    {
        Task CreateAsync(PaymentLogging entity);
    }
}
