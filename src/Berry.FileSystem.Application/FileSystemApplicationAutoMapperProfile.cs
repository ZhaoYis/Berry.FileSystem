using AutoMapper;
using Berry.FileSystem.FileDownload.Dto;
using Berry.FileSystem.FileDownload.Handlers.Dto;
using Berry.FileSystem.FileUpload.Dto;
using Berry.FileSystem.FileUpload.Handlers.Dto;

namespace Berry.FileSystem;

public class FileSystemApplicationAutoMapperProfile : Profile
{
    public FileSystemApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<FileUploadInput, UploadInput>();
        CreateMap<UploadDto, FileUploadDto>();

        CreateMap<FileDownloadInput, DownloadInput>();
        CreateMap<DownloadDto, FileDownloadDto>();
    }
}