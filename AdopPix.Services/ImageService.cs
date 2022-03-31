using AdopPix.Services.IServices;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration configuration;

        public ImageService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Succeeded { get; private set; }

        public bool ValidateExtension(string[] extension, IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string fileExt = Path.GetExtension(fileName);

            for(int index = 0; index < extension.Length; index++)
            {
                if(fileExt == extension[index]) return true;
            }
            return false;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            string name = string.Empty;
            try
            {
                name = $"{GenerateFileName()}";
                using (var client = new AmazonS3Client(configuration["AWSS3_PublicKey"],
                                                       configuration["AWSS3_SecretKey"], 
                                                       Amazon.RegionEndpoint.APSoutheast1))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);

                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = memoryStream,
                            Key = name,
                            BucketName = configuration["AWSS3_BucketKey"]
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        await fileTransferUtility.UploadAsync(uploadRequest);
                    }
                }
                Succeeded = true;
            }
            catch
            {
                Succeeded = false;
            }
            return name;
        }

        private string GenerateFileName()
        {
            string[] dateTime = DateTime.Now.ToString().Split(' ');
            string[] ddmmyyyy = dateTime[0].Split('/');
            string[] hhmmss = dateTime[1].Split(':');
            return $"adoppix-{string.Join("", ddmmyyyy)}{string.Join("", hhmmss)}";
        }
    }
}
