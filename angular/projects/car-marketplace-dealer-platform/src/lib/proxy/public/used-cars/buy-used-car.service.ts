import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BuyUsedCarService {
  apiName = 'CarMarketplace';
  

  create = (input: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, any>({
      method: 'POST',
      url: '/api/car-marketplace-public/buy-used-car',
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
