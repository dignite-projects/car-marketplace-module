import type { UsedCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BuyUsedCarService {
  apiName = 'CarMarketplace';
  

  create = (input: UsedCarDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'POST',
      url: '/api/car-marketplace-public/buy-used-car',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
