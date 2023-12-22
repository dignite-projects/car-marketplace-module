import type { BrandDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
  apiName = 'CarMarketplace';

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<BrandDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/brand',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
