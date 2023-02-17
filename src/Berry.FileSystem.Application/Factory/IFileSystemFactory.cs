using Berry.FileSystem.Enumeration;
using Berry.FileSystem.FileDownload.Handlers;
using Berry.FileSystem.FileUpload.Handlers;
using Volo.Abp.DependencyInjection;

namespace Berry.FileSystem.Factory;

public interface IFileSystemFactory : ITransientDependency
{
    IFileUploadHandler GetUploadHandler(FileContainerType containerType);

    IFileDownloadHandler GetDownloadHandler(FileContainerType containerType);
}