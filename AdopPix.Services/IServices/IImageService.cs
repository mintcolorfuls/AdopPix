using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface IImageService
    {
        public bool Succeeded { get; }
        bool ValidateExtension(string[] extension, IFormFile file);
        Task<string> UploadImageAsync(IFormFile file);
        Task<string> UploadAuctionImageAsync(IFormFile file);
    }
}
