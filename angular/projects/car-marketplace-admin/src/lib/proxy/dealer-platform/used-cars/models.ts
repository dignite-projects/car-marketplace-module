import type { CreationAuditedEntityDto, PagedAndSortedResultRequestDto, PagedResultRequestDto } from '@abp/ng.core';
import type { UsedCarStatus } from '../../used-cars/used-car-status.enum';

export interface BuyUsedCarDto extends CreationAuditedEntityDto<string> {
  usedCarId?: string;
  usedCar: UsedCarDto;
  contactPerson?: string;
  contactNumber?: string;
  reservationTime?: string;
}

export interface GetBuyUsedCarsInput extends PagedResultRequestDto {
  filter?: string;
}

export interface GetUsedCarsInput extends PagedAndSortedResultRequestDto {
  filter?: string;
  status?: UsedCarStatus;
}

export interface UsedCarCreateDto extends UsedCarCreateOrUpdateDtoBase {
}

export interface UsedCarCreateOrUpdateDtoBase {
  trimId: string;
  name: string;
  description?: string;
  status: UsedCarStatus;
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
}

export interface UsedCarUpdateDto extends UsedCarCreateOrUpdateDtoBase {
}
