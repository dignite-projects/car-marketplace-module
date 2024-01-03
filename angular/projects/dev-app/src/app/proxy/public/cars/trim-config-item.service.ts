import type { TrimConfigItemDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TrimConfigItemService {
  apiName = 'CarMarketplace';
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<TrimConfigItemDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/trim-config-item',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
