import type { GetSaleUsedCarsInput, SaleUsedCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SaleUsedCarService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SaleUsedCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-admin/sale-used-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSaleUsedCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SaleUsedCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-admin/sale-used-car',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
