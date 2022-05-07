using AdopPix.Models.ViewModels;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface INavbarService
    {
        Task<NavbarViewModel> FindByNameAsync(string username);
    }
}
