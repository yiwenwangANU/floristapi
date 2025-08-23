
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FloristApi.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobContainerClient _container;
        public BlobService(IConfiguration config)
        {
            var conn = config["ConnectionStrings:floristapi:storage"];
            var containerName = config["AzureBlob:Container"];

            var service = new BlobServiceClient(conn);
            _container = service.GetBlobContainerClient(containerName);
            _container.CreateIfNotExists();
        }
        public async Task<string> UploadAsync(Stream content, string fileName, string contentType, CancellationToken ct = default)
        {
            var safeName = $"{Guid.NewGuid():N}{Path.GetExtension(fileName)}";
            var blob = _container.GetBlobClient(safeName);

            var headers = new BlobHttpHeaders { ContentType = contentType };
            await blob.UploadAsync(content, new BlobUploadOptions { HttpHeaders = headers }, ct);

            return blob.Uri.ToString();
        }
        public async Task DeleteAsync(string blobName, CancellationToken ct)
        {
            var blobClient = _container.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync(cancellationToken: ct);
        }
    }
}
