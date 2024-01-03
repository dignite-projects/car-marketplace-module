import type { CreationAuditedEntityDto, PagedAndSortedResultRequestDto, PagedResultRequestDto } from '@abp/ng.core';
import type { ModelDto } from '../cars/models';
import type { UsedCarStatus } from '../../used-cars/used-car-status.enum';
import type { DealerDto } from '../dealers/models';

export interface GetSaleUsedCarsInput extends PagedResultRequestDto {
}

export interface GetUsedCarsInput extends PagedAndSortedResultRequestDto {
  usedCarId?: number;
}

export interface SaleUsedCarDto extends CreationAuditedEntityDto<string> {
  modelId?: string;
  model: ModelDto;
  description?: string;
  registrationDate?: string;
  totalMileage: number;
  address?: string;
  contactPerson?: string;
  contactNumber?: string;
}

export interface UsedCarDto extends CreationAuditedEntityDto<string> {
  usedCarId: number;
  brandId?: string;
  modelId?: string;
  trimId?: string;
  name?: string;
  description?: string;
  status: UsedCarStatus;
  dealerId?: string;
  registrationDate?: string;
  totalMileage: number;
  transfersCount: number;
  compulsoryInsuranceExpirationDate?: string;
  commercialInsuranceExpirationDate?: string;
  color?: string;
  price: number;
  transmissionType?: string;
  powerType?: string;
  modelLevel?: string;
  tags: string[];
  dealer: DealerDto;
}
