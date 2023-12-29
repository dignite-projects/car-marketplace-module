import type { SaleCarCreateDto, SaleCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SaleUsedCarService {
  apiName = 'CarMarketplace';
  

  create = (input: SaleCarCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, SaleCarDto>({
      method: 'POST',
      url: '/api/car-marketplace-public/sale-used-car',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
