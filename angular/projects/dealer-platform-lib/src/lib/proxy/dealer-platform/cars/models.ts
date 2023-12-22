import type { CreationAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CarStatus } from '../../cars/car-status.enum';

export interface GetUsedCarsInput extends PagedAndSortedResultRequestDto {
  filter?: string;
  status?: CarStatus;
}

export interface UsedCarCreateDto extends UsedCarCreateOrUpdateDtoBase {
}

export interface UsedCarCreateOrUpdateDtoBase {
  trimId: string;
  name: string;
  description?: string;
  status: CarStatus;
  registrationDate: string;
  totalMileage: number;
  transfersCount: number;
  compulsoryInsuranceExpirationDate?: string;
  commercialInsuranceExpirationDate?: string;
  color?: string;
  price: number;
  tags: string[];
}

export interface UsedCarDto extends CreationAuditedEntityDto<string> {
  usedCarId: number;
  brandId?: string;
  modelId?: string;
  trimId?: string;
  name?: string;
  description?: string;
  status: CarStatus;
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
}

export interface UsedCarUpdateDto extends UsedCarCreateOrUpdateDtoBase {
}
