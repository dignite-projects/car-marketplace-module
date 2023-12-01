import type { DealerCreateDto, DealerDto, DealerUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CmsUserDto } from '../../volo/cms-kit/users/models';

@Injectable({
  providedIn: 'root',
})
export class DealerService {
  apiName = 'CarMarketplace';
  

  addAdministratorByUserId = (userId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/car-marketplace-dealer-platform/dealer/add-administrator',
      params: { userId },
    },
    { apiName: this.apiName,...config });
  

  create = (input: DealerCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'POST',
      url: '/api/car-marketplace-dealer-platform/dealer',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  findByCurrentUser = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'GET',
      url: '/api/car-marketplace-dealer-platform/dealer/find-by-current-user',
    },
    { apiName: this.apiName,...config });
  

  getAdministrators = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<CmsUserDto>>({
      method: 'GET',
      url: '/api/car-marketplace-dealer-platform/dealer/administrators',
    },
    { apiName: this.apiName,...config });
  

  removeAdministrator = (userId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/car-marketplace-dealer-platform/dealer/remove-administrator',
      params: { userId },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: DealerUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'PUT',
      url: `/api/car-marketplace-dealer-platform/dealer/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
