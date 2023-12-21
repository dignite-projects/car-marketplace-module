import type { GetSaleCarsInput, SaleCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SaleCarService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SaleCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-admin/sale-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetSaleCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<SaleCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-admin/sale-car',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
