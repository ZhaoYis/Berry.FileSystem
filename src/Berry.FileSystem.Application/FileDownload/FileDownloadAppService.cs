using System.Threading.Tasks;
using Berry.FileSystem.Factory;
using Berry.FileSystem.FileDownload.Dto;
using Berry.FileSystem.FileDownload.Handlers.Dto;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Berry.FileSystem.FileDownload;

[RemoteService(IsEnabled = false, IsMetadataEnabled = false)]
public class FileDownloadAppService : ApplicationService, IFileDownloadAppService
{
    private readonly IFileSystemFactory _fileSystemFactory;

    public FileDownloadAppService(IFileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
    }

    /// <summary>
    ///     文件下载
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<FileDownloadDto> DownloadAsync(FileDownloadInput input)
    {
        var downloadHandler = _fileSystemFactory.GetDownloadHandler(input.ContainerType);

        var downloadInput = ObjectMapper.Map<FileDownloadInput, DownloadInput>(input);
        var dto = await downloadHandler.HandleAsync(downloadInput);

        return ObjectMapper.Map<DownloadDto, FileDownloadDto>(dto);
    }
}