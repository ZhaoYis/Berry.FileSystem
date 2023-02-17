using System.Threading.Tasks;
using Berry.FileSystem.Configuration;
using Berry.FileSystem.FileUpload.Handlers.Dto;
using Berry.FileSystem.FileUpload.Providers;
using Berry.FileSystem.FileUpload.Providers.Dto;
using Microsoft.Extensions.Options;
using Volo.Abp.BlobStoring;
using Volo.Abp.Timing;

namespace Berry.FileSystem.FileUpload.Handlers.Impl;

public class FileUpload4DefaultHandler : IFileUploadHandler
{
    private readonly IBlobContainer<DefaultContainer> _blobContainer;
    private readonly IClock _clock;

    private readonly IFileKeyProvider _fileKeyProvider;

    public FileUpload4DefaultHandler(IBlobContainer<DefaultContainer> blobContainer, 
        IClock clock, 
        IFileKeyProvider fileKeyProvider, 
        IOptions<FileUploadOptions> options)
    {
        _blobContainer = blobContainer;
        _clock = clock;

        _fileKeyProvider = fileKeyProvider;

        Options = options.Value;
    }

    protected FileUploadOptions Options { get; }

    /// <summary>
    ///     处理文件
    /// </summary>
    /// <returns></returns>
    public async Task<UploadDto> HandleAsync(UploadInput input)
    {
        var uploadFileName = input.FormFile.FileName;
        var fileKeyResult = await _fileKeyProvider.GetFileKeyAsync(new FileKeyProviderGetArgs(input.ClientId, uploadFileName));

        //保存文件
        if (await _blobContainer.ExistsAsync(fileKeyResult.FilePath))
        {
            if (Options.OverrideExisting)
            {
                await _blobContainer.SaveAsync(fileKeyResult.FilePath, input.FormFile.OpenReadStream(), Options.OverrideExisting);
            }
            else
            {
                if (Options.ResettingFileNameIfExisting)
                {
                    //重新计算资源名称
                    fileKeyResult = await _fileKeyProvider.GetFileKeyAsync(new FileKeyProviderGetArgs(input.ClientId, string.Format("{0}_{1}", _clock.Now.Ticks, uploadFileName)));
                    await _blobContainer.SaveAsync(fileKeyResult.FilePath, input.FormFile.OpenReadStream(), Options.OverrideExisting);
                }
                else
                {
                    throw new BlobAlreadyExistsException(string.Format("{0}已经存在", uploadFileName));
                }
            }
        }
        else
        {
            await _blobContainer.SaveAsync(fileKeyResult.FilePath, input.FormFile.OpenReadStream(), Options.OverrideExisting);
        }

        return new UploadDto { FileKey = fileKeyResult.FileKey, FilePath = fileKeyResult.FilePath };
    }
}