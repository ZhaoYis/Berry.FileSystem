using Berry.FileSystem.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Berry.FileSystem;

[DependsOn(
    typeof(FileSystemApplicationContractsModule)
)]
public class FileSystemHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FileSystemResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}