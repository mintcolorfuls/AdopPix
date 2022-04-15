using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        Task CompleateAsync();
    }
}
