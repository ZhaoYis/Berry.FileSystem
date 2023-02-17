using System.Threading.Tasks;
using Berry.FileSystem.FileDownload.Handlers.Dto;
using Berry.FileSystem.FileUpload.Providers;
using Microsoft.AspNetCore.StaticFiles;
using Volo.Abp;
using Volo.Abp.BlobStoring;

namespace Berry.FileSystem.FileDownload.Handlers.Impl;

public class FileDownloadDefaultHandler : IFileDownloadHandler
{
    private readonly IBlobContainer<DefaultContainer> _blobContainer;
    private readonly IContentTypeProvider _fileExtensionContentTypeProvider;

    private readonly IFileKeyProvider _fileKeyProvider;

    public FileDownloadDefaultHandler(IBlobContainer<DefaultContainer> blobContainer, IFileKeyProvider fileKeyProvider)
    {
        _blobContainer = blobContainer;
        _fileExtensionContentTypeProvider = new FileExtensionContentTypeProvider();

        _fileKeyProvider = fileKeyProvider;
    }

    /// <summary>
    ///     处理文件
    /// </summary>
    /// <returns></returns>
    public async Task<DownloadDto> HandleAsync(DownloadInput input)
    {
        Check.NotNullOrWhiteSpace(input.FileKey, nameof(input.FileKey));

        var filePath = await _fileKeyProvider.GetBlobNameFromFileKeyAsync(input.FileKey);

        var isExist = await _blobContainer.ExistsAsync(filePath);
        if (isExist)
        {
            var isSucc = _fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType);
            if (isSucc)
            {
                var bytes = await _blobContainer.GetAllBytesAsync(filePath);

                return new DownloadDto { FileBytes = bytes, ContentType = contentType };
            }
        }

        return default;
    }
}