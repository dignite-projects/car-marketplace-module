// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using Dignite.CarMarketplace.Public.UsedCars;
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
namespace Dignite.CarMarketplace.Public.UsedCars;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(ISaleUsedCarPublicAppService), typeof(SaleUsedCarClientProxy))]
public partial class SaleUsedCarClientProxy : ClientProxyBase<ISaleUsedCarPublicAppService>, ISaleUsedCarPublicAppService
{
    public virtual async Task<SaleCarDto> CreateAsync(SaleCarCreateDto input)
    {
        return await RequestAsync<SaleCarDto>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SaleCarCreateDto), input }
        });
    }
}
