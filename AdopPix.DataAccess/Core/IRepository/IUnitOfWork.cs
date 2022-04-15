using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IRepository
{
    public interface IUnitOfWork
    {
        Task CompleateAsync();
    }
}
