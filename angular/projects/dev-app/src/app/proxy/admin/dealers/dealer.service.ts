import type { DealerDto, DealerExcelDownloadInput, GetDealersInput } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AuthenticationStatus } from '../../dealers/authentication-status.enum';

@Injectable({
  providedIn: 'root',
})
export class DealerService {
  apiName = 'CarMarketplace';
  

  authenticateByIdAndStatus = (id: string, status: AuthenticationStatus, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/car-marketplace-admin/dealer/${id}/authenticate`,
      params: { status },
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/car-marketplace-admin/dealer/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DealerDto>({
      method: 'GET',
      url: `/api/car-marketplace-admin/dealer/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetDealersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DealerDto>>({
      method: 'GET',
      url: '/api/car-marketplace-admin/dealer',
      params: { filter: input.filter, authenticationStatus: input.authenticationStatus, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: DealerExcelDownloadInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/car-marketplace-admin/dealer/as-excel-file',
      params: { authenticationStatus: input.authenticationStatus },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
