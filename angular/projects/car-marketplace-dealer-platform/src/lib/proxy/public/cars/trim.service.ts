import type { GetTrimsInput, TrimDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TrimService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TrimDto>({
      method: 'GET',
      url: `/api/car-marketplace-public/trim/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetTrimsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TrimDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/trim',
      params: { modelId: input.modelId },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
