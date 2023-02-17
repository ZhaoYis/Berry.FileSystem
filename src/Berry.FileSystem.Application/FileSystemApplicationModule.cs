using System.Linq;
using Berry.FileSystem.Configuration;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Modularity;

namespace Berry.FileSystem;

[DependsOn(
    typeof(FileSystemDomainModule),
    typeof(FileSystemApplicationContractsModule),
    typeof(AbpBlobStoringModule),
    typeof(AbpBlobStoringFileSystemModule)
)]
public class FileSystemApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<FileSystemApplicationModule>(); });

        //文件上传配置
        Configure<FileUploadOptions>(options =>
        {
#if DEBUG
            var provider = new FileExtensionContentTypeProvider();
            options.Extensions = provider.Mappings.Keys.ToList();
#else
            options.Extensions = new List<string> { "zip" };
#endif

            options.OverrideExisting = true;
            options.ResettingFileNameIfExisting = true;
        });

        //BLOB配置
        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.ConfigureAll((containerName, container) =>
            {
                container.UseFileSystem(fileSystem => { fileSystem.BasePath = configuration["BlobStoring:FileSystem:BasePath"]; });
                container.ProviderType = typeof(FileSystemBlobProvider);
                container.IsMultiTenant = true;
            });
        });
    }
}