import type { GetModelsInput, ModelCompanyDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModelService {
  apiName = 'CarMarketplace';
  

  getList = (input: GetModelsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<ModelCompanyDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/model',
      params: { brandId: input.brandId },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
