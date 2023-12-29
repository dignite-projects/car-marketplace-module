import type { DealerDto, GetDealersInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DealerService {
  apiName = 'CarMarketplace';
  

  findByShortName = (shortName: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'GET',
      url: `/api/car-marketplace-public/dealer/find/${shortName}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'GET',
      url: `/api/car-marketplace-public/dealer/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetDealersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DealerDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/dealer',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
