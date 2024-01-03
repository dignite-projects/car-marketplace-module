import type { BuyUsedCarDto, GetBuyUsedCarsInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BuyUsedCarService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BuyUsedCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-dealer-platform/buy-used-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetBuyUsedCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BuyUsedCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-dealer-platform/buy-used-car',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
