import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminLibService {

  apiName = 'CarMarketplace';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CarMarketplace/sample' },
      { apiName: this.apiName }
    );
  }
}
