import type { UsedCarConsultationCreateDto, UsedCarConsultationDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsedCarConsultationService {
  apiName = 'CarMarketplace';
  

  create = (input: UsedCarConsultationCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarConsultationDto>({
      method: 'POST',
      url: '/api/car-marketplace-dealer-platform/used-car-consultation',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
