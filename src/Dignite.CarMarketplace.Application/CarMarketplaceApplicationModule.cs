using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Microsoft.AspNetCore.Authorization;
using Dignite.CarMarketplace.DealerPlatform.Dealers;
using Dignite.CmsKit.Public;
using Dignite.FileExplorer;
using Volo.Abp.BlobStoring;
using Dignite.CarMarketplace.BlobStoring;
using Dignite.Abp.BlobStoring;
using System.Collections.Generic;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceDomainModule),
    typeof(CarMarketplaceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(DigniteCmsKitPublicApplicationModule),
    typeof(FileExplorerApplicationModule)
    )]
public class CarMarketplaceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CarMarketplaceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CarMarketplaceApplicationModule>(validate: true);
        });

        Configure<AuthorizationOptions>(options =>
        {
            options.AddPolicy("CarMarketplaceUpdatePolicy", policy => policy.Requirements.Add(CommonOperations.Update));
            options.AddPolicy("CarMarketplaceDeletePolicy", policy => policy.Requirements.Add(CommonOperations.Delete));
            options.AddPolicy("UsedCarManagePolicy", policy => policy.Requirements.Add(CommonOperations.UsedCarManage));
        });

        context.Services.AddSingleton<IAuthorizationHandler, DealerAuthorizationHandler>();


        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers
                .Configure<CarPicsBlobContainer>(container =>
                {
                    container.AddFileSizeLimitHandler(handler =>
                    {
                        handler.MaxFileSize = 10240;
                    });
                    container.AddFileTypeCheckHandler(handler =>
                    {
                        handler.AllowedFileTypeNames = new string[] { ".jpg", ".jpeg", ".png" };
                    });
                    container.AddImageResizeHandler(handler =>
                    {
                        handler.ImageWidth = 600;
                        handler.ImageHeight = 400;
                    });
                    container.SetFileGridConfiguration(fg => fg.FileCells = new List<FileCell>
                    {
                        new FileCell("左前"),
                        new FileCell("右后"),
                        new FileCell("侧面"),
                        new FileCell("正后"),
                        new FileCell("驾驶座"),
                        new FileCell("仪表盘"),
                        new FileCell("前排"),
                        new FileCell("后排"),
                        new FileCell("后备箱"),
                        new FileCell("发动机舱")
                    });
                });
        });
    }
}
