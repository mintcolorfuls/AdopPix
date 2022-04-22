 using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Core.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger logger;

        public IUserProfileRepository UserProfile { get; private set; }
        public IPaymentLoggingRepository PaymentLogging { get; private set; }
        public ISocialMediaRepository SocialMedia { get; private set; }
        public ISocialMediaTypeRepository SocialMediaType { get; private set; }

        public UnitOfWork(ApplicationDbContext context,
                          ILoggerFactory logger)
        {
            this.context = context;
            this.logger = logger.CreateLogger("Log");

            UserProfile = new UserProfileRepository(context, this.logger);
            PaymentLogging = new PaymentLoggingRepository(context, this.logger);
            SocialMedia = new SocialMediaRepository(context, this.logger);
            SocialMediaType = new SocialMediaTypeRepository(context, this.logger);
        }
        public async Task CompleateAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
