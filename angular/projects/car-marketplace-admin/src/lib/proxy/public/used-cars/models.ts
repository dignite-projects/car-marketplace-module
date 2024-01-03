import type { AuditedEntityDto, CreationAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { UsedCarStatus } from '../../used-cars/used-car-status.enum';
import type { DealerDto } from '../dealers/models';

export interface GetUsedCarsInput extends PagedAndSortedResultRequestDto {
  filter?: string;
  brandId?: string;
  modelId?: string;
  dealerId?: string;
  color?: string;
  minRegistrationDate?: string;
  maxRegistrationDate?: string;
  minTotalMileage?: number;
  maxTotalMileage?: number;
  minPrice?: number;
  maxPrice?: number;
  transmissionType?: string;
  powerType?: string;
  modelLevel?: string;
  tagName?: string;
}

export interface SaleCarCreateDto {
  modelId: string;
  description?: string;
  registrationDate: string;
  totalMileage: number;
  address: string;
  contactPerson: string;
  contactNumber: string;
}

export interface SaleCarDto extends CreationAuditedEntityDto<string> {
  modelId?: string;
  description?: string;
  registrationDate?: string;
  totalMileage: number;
  address?: string;
  contactPerson?: string;
  contactNumber?: string;
}

export interface UsedCarDto extends AuditedEntityDto<string> {
  usedCarId: number;
  brandId?: string;
  modelId?: string;
  trimId?: string;
  name?: string;
  description?: string;
  status: UsedCarStatus;
  dealerId?: string;
  dealer: DealerDto;
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
}
