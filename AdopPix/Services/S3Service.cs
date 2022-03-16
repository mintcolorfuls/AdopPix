using AdopPix.Services.IService;
using AdopPix.Settings;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class S3Service : IS3Service
    {
        private readonly IOptions<AwsS3Configuration> awsS3Configuration;

        public S3Service(IOptions<AwsS3Configuration> awsS3Configuration)
        {
            this.awsS3Configuration = awsS3Configuration;
        }

        public bool Succeed { get; private set; }
        public string ErrorMsg { get; private set; } = "";

        public async Task UploadAsync(IFormFile file, string fileName)
        {
            try
            {
                using (var client = new AmazonS3Client(awsS3Configuration.Value.AccessKey,
                                                  awsS3Configuration.Value.SecretKey,
                                                  Amazon.RegionEndpoint.APSoutheast1))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);

                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = memoryStream,
                            Key = fileName,
                            BucketName = awsS3Configuration.Value.BucketName,
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        await fileTransferUtility.UploadAsync(uploadRequest);
                        Succeed = true;
                    }
                }
                Console.WriteLine($"Upload to {awsS3Configuration.Value.BucketName} is {Succeed}, file name is ${fileName}");
            }
            catch
            {
                Succeed = true;
                ErrorMsg = "Server down";
            }
            
        }
    }
}
