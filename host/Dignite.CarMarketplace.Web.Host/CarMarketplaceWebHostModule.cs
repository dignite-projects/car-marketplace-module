using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Dignite.CarMarketplace.Localization;
using Dignite.CarMarketplace.MultiTenancy;
using Dignite.CarMarketplace.Web;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web;
using Volo.Abp.Http.Client.Web;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.Security.Claims;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Dignite.CarMarketplace;

[DependsOn(
    typeof(CarMarketplaceWebModule),
    typeof(CarMarketplaceHttpApiClientModule),
    typeof(CarMarketplaceHttpApiModule),
    typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
    typeof(AbpAspNetCoreMvcClientModule),
    typeof(AbpHttpClientWebModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpIdentityWebModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpFeatureManagementWebModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpTenantManagementWebModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(AbpSettingManagementWebModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
    )]
public class CarMarketplaceWebHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(CarMarketplaceResource),
                typeof(CarMarketplaceDomainSharedModule).Assembly,
                typeof(CarMarketplaceApplicationContractsModule).Assembly,
                typeof(CarMarketplaceWebHostModule).Assembly
            );
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureMenu(configuration);
        ConfigureCache(configuration);
        ConfigureUrls(configuration);
        ConfigureAuthentication(context, configuration);
        ConfigureAutoMapper();
        ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureSwaggerServices(context.Services);
        ConfigureMultiTenancy();
        ConfigureDataProtection(context, configuration, hostingEnvironment);
    }

    private void ConfigureMenu(IConfiguration configuration)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new CarMarketplaceWebHostMenuContributor(configuration));
        });
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "CarMarketplace:";
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });
    }

    private void ConfigureMultiTenancy()
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.CheckTokenExpiration();
            })
            .AddAbpOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                options.ClientId = configuration["AuthServer:ClientId"];
                options.ClientSecret = configuration["AuthServer:ClientSecret"];

                options.UsePkce = true;
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("roles");
                options.Scope.Add("email");
                options.Scope.Add("phone");
                options.Scope.Add("CarMarketplace");
            });
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CarMarketplaceWebHostModule>();
        });
    }

    private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<CarMarketplaceDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dignite.CarMarketplace.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CarMarketplaceApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dignite.CarMarketplace.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CarMarketplaceWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Dignite.CarMarketplace.Web", Path.DirectorySeparatorChar)));
            });
        }
    }

    private void ConfigureSwaggerServices(IServiceCollection services)
    {
        services.AddAbpSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CarMarketplace API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            }
        );
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("CarMarketplace");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "CarMarketplace-Protection-Keys");
        }
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseErrorPage();
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAbpRequestLocalization();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "CarMarketplace API");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
