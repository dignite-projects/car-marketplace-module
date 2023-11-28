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
using Microsoft.Extensions.Localization;
using Volo.Abp.Localization;
using Dignite.CarMarketplace.Localization;

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
            var stringLocalizerFactory = context.Services.GetRequiredService<IStringLocalizerFactory>();
            var stringLocalizer = stringLocalizerFactory.Create(typeof(CarMarketplaceResource));

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
                        new FileCell("LeftFront",L("LeftFront")),               //左前方
                        new FileCell("RightRear",L("RightRear")),               //右后方
                        new FileCell("Side",L("Side")),                         //侧面
                        new FileCell("DirectlyFront",L("DirectlyFront")),       //正前
                        new FileCell("DirectlyBehind",L("DirectlyBehind")),     //正后
                        new FileCell("WingSection",L("WingSection")),           //中控
                        new FileCell("FrontRow",L("FrontRow")),                 //前排
                        new FileCell("BehindRow",L("BehindRow")),               //后排
                        new FileCell("Trunk",L("Trunk")),                       //后备箱
                        new FileCell("EngineRoom",L("EngineRoom"))              //发动机舱
                    });
                });
        });
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CarMarketplaceResource>(name);
    }
}
