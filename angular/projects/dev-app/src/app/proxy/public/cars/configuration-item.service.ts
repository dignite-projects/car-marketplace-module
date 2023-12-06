import type { ConfigurationItemDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationItemService {
  apiName = 'CarMarketplace';
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<ConfigurationItemDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/configuration-item',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
