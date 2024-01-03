import type { GetUsedCarsInput, UsedCarDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsedCarService {
  apiName = 'CarMarketplace';
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-public/usedcar/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllModelColors = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string[]>({
      method: 'GET',
      url: '/api/car-marketplace-public/usedcar/all-model-colors',
    },
    { apiName: this.apiName,...config });
  

  getAllModelLevels = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string[]>({
      method: 'GET',
      url: '/api/car-marketplace-public/usedcar/all-model-levels',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUsedCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UsedCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-public/usedcar',
      params: { filter: input.filter, brandId: input.brandId, modelId: input.modelId, dealerId: input.dealerId, color: input.color, minRegistrationDate: input.minRegistrationDate, maxRegistrationDate: input.maxRegistrationDate, minTotalMileage: input.minTotalMileage, maxTotalMileage: input.maxTotalMileage, minPrice: input.minPrice, maxPrice: input.maxPrice, transmissionType: input.transmissionType, powerType: input.powerType, modelLevel: input.modelLevel, tagName: input.tagName, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
