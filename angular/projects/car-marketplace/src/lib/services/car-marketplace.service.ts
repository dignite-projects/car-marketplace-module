import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CarMarketplaceService {
  apiName = 'CarMarketplace';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CarMarketplace/sample' },
      { apiName: this.apiName }
    );
  }
}
