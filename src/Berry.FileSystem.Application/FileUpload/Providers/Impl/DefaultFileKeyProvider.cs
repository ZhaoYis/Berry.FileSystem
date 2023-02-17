using System.Threading.Tasks;
using Berry.FileSystem.FileUpload.Providers.Dto;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Encryption;

namespace Berry.FileSystem.FileUpload.Providers.Impl;

[ExposeServices(typeof(IFileKeyProvider))]
public class DefaultFileKeyProvider : FileKeyProviderBase
{
    private readonly IStringEncryptionService _stringEncryptionService;

    public DefaultFileKeyProvider(IStringEncryptionService stringEncryptionService)
    {
        _stringEncryptionService = stringEncryptionService;
    }

    /// <summary>
    ///     计算文件标识码
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override Task<FileKeyProviderDto> GetFileKeyAsync(FileKeyProviderGetArgs args)
    {
        var filePath = string.Format("{0}/{1}", args.ClientId, args.FileName);

        var fileKey = _stringEncryptionService.Encrypt(filePath);

        return Task.FromResult(new FileKeyProviderDto { FileKey = fileKey, FilePath = filePath });
    }

    /// <summary>
    ///     根据文件标识码获取BLOB名称
    /// </summary>
    /// <param name="fileKey"></param>
    /// <returns></returns>
    public override Task<string> GetBlobNameFromFileKeyAsync(string fileKey)
    {
        Check.NotNullOrWhiteSpace(fileKey, nameof(fileKey));

        var blobName = _stringEncryptionService.Decrypt(fileKey);

        return Task.FromResult(blobName);
    }
}