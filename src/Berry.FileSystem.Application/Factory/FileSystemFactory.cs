using System;
using Berry.FileSystem.Enumeration;
using Berry.FileSystem.FileDownload.Handlers;
using Berry.FileSystem.FileDownload.Handlers.Impl;
using Berry.FileSystem.FileUpload.Handlers;
using Berry.FileSystem.FileUpload.Handlers.Impl;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Berry.FileSystem.Factory;

[ExposeServices(typeof(IFileSystemFactory))]
public class FileSystemFactory : IFileSystemFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FileSystemFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IFileUploadHandler GetUploadHandler(FileContainerType containerType)
    {
        switch (containerType)
        {
            default:
                return _serviceProvider.GetRequiredService<FileUpload4DefaultHandler>();
        }
    }

    public IFileDownloadHandler GetDownloadHandler(FileContainerType containerType)
    {
        switch (containerType)
        {
            default:
                return _serviceProvider.GetRequiredService<FileDownloadDefaultHandler>();
        }
    }
}