import type { GetUsedCarConsultationsInput, UsedCarConsultationDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsedCarConsultationService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarConsultationDto>({
      method: 'GET',
      url: `/api/car-marketplace-dealer-platform/used-car-consultation/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUsedCarConsultationsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UsedCarConsultationDto>>({
      method: 'GET',
      url: '/api/car-marketplace-dealer-platform/used-car-consultation',
      params: { filter: input.filter, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
