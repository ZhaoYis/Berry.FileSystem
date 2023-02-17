using Volo.Abp.Modularity;

namespace Berry.FileSystem;

[DependsOn(
    typeof(FileSystemDomainSharedModule)
)]
public class FileSystemDomainModule : AbpModule
{
    
}