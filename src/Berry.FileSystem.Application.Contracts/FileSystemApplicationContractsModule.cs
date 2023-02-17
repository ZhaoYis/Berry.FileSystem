using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Berry.FileSystem;

[DependsOn(
    typeof(FileSystemDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class FileSystemApplicationContractsModule : AbpModule
{
    
}