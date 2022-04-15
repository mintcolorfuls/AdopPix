using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.DataAccess.Core.IRepository;
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

        public UnitOfWork(ApplicationDbContext context,
                          ILoggerFactory logger)
        {
            this.context = context;
            this.logger = logger.CreateLogger("Log");
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
