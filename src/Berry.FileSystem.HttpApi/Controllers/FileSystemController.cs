using System.Threading.Tasks;
using Berry.FileSystem.FileDownload;
using Berry.FileSystem.FileDownload.Dto;
using Berry.FileSystem.FileUpload;
using Berry.FileSystem.FileUpload.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Berry.FileSystem.Controllers;

/// <summary>
///     文件系统
/// </summary>
[Route("api/v1/file-system")]
public class FileSystemController : ControllerBase
{
    private readonly IFileDownloadAppService _fileDownloadAppService;
    private readonly IFileUploadAppService _fileUploadAppService;

    public FileSystemController(IFileUploadAppService fileUploadAppService,
        IFileDownloadAppService fileDownloadAppService)
    {
        _fileUploadAppService = fileUploadAppService;
        _fileDownloadAppService = fileDownloadAppService;
    }

    /// <summary>
    ///     文件上传
    /// </summary>
    /// <returns></returns>
    [HttpPost, Route("upload")]
    public async Task<FileUploadDto> UploadAsync([FromForm] FileUploadInput input)
    {
        return await _fileUploadAppService.UploadAsync(input);
    }

    /// <summary>
    ///     文件下载
    /// </summary>
    /// <returns></returns>
    [HttpGet, Route("download")]
    public async Task<FileContentResult> DownloadAsync([FromBody] FileDownloadInput input)
    {
        var download = await _fileDownloadAppService.DownloadAsync(input);
        var fileContentResult = new FileContentResult(download.FileBytes, download.ContentType);

        return fileContentResult;
    }
}