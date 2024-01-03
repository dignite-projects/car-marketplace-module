import type { GetUsedCarsInput, UsedCarCreateDto, UsedCarDto, UsedCarUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { UsedCarStatus } from '../../used-cars/used-car-status.enum';

@Injectable({
  providedIn: 'root',
})
export class UsedCarService {
  apiName = 'CarMarketplace';
  

  create = (input: UsedCarCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'POST',
      url: '/api/car-marketplace-dealer-platform/used-car',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/car-marketplace-dealer-platform/used-car',
      params: { id },
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'GET',
      url: `/api/car-marketplace-dealer-platform/used-car/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUsedCarsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UsedCarDto>>({
      method: 'GET',
      url: '/api/car-marketplace-dealer-platform/used-car',
      params: { filter: input.filter, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  setStatus = (id: string, status: UsedCarStatus, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/car-marketplace-dealer-platform/used-car/${id}/set-status`,
      params: { status },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UsedCarUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UsedCarDto>({
      method: 'PUT',
      url: `/api/car-marketplace-dealer-platform/used-car/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
