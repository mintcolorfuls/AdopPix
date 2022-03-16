using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AdopPix.Services.IService
{
    public interface IS3Service
    {
        public bool Succeed { get; }
        public string ErrorMsg { get; }
        public Task UploadAsync(IFormFile file, string fileName);
    }
}
