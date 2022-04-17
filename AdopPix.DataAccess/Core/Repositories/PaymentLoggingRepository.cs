using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.Extensions.Logging;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class PaymentLoggingRepository : Repository<PaymentLogging>, IPaymentLoggingRepository
    {
        public PaymentLoggingRepository(ApplicationDbContext context, ILogger logger) 
            : base(context, logger)
        {
        }
    }
}
