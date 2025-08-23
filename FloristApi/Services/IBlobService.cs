namespace FloristApi.Services
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream content, string fileName, string contentType, CancellationToken ct = default);
        Task DeleteAsync(string blobName, CancellationToken ct = default);
    }
}
