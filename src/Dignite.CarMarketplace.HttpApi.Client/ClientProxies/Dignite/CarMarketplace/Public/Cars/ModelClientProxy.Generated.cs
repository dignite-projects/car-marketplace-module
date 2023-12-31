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
[ExposeServices(typeof(IModelPublicAppService), typeof(ModelClientProxy))]
public partial class ModelClientProxy : ClientProxyBase<IModelPublicAppService>, IModelPublicAppService
{
    public virtual async Task<ListResultDto<ModelCompanyDto>> GetListAsync(GetModelsInput input)
    {
        return await RequestAsync<ListResultDto<ModelCompanyDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(GetModelsInput), input }
        });
    }
}
