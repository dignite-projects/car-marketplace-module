// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using Dignite.CarMarketplace.Public.Cars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Abp.Http.Modeling;

// ReSharper disable once CheckNamespace
namespace Dignite.CarMarketplace.Public.Cars;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IBrandPublicAppService), typeof(BrandClientProxy))]
public partial class BrandClientProxy : ClientProxyBase<IBrandPublicAppService>, IBrandPublicAppService
{
    public virtual async Task<ListResultDto<BrandDto>> GetListAsync()
    {
        return await RequestAsync<ListResultDto<BrandDto>>(nameof(GetListAsync));
    }
}
