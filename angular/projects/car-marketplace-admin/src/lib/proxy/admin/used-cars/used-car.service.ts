import type { GetUsedCarsInput, UsedCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsedCarService {
  apiName = 'CarMarketplace';
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/car-marketplace-admin/used-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-admin/used-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUsedCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UsedCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-admin/used-car',
      params: { usedCarId: input.usedCarId, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
