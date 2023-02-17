using System.Threading.Tasks;
using Berry.FileSystem.Factory;
using Berry.FileSystem.FileUpload.Dto;
using Berry.FileSystem.FileUpload.Handlers.Dto;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Berry.FileSystem.FileUpload;

[RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
public class FileUploadAppService : ApplicationService, IFileUploadAppService
{
    private readonly IFileSystemFactory _fileSystemFactory;

    public FileUploadAppService(IFileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
    }

    /// <summary>
    ///     文件上传
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<FileUploadDto> UploadAsync(FileUploadInput input)
    {
        var uploadHandler = _fileSystemFactory.GetUploadHandler(input.ContainerType);
        var uploadInput = ObjectMapper.Map<FileUploadInput, UploadInput>(input);
        var dto = await uploadHandler.HandleAsync(uploadInput);

        return ObjectMapper.Map<UploadDto, FileUploadDto>(dto);
    }
}