import type { CreationAuditedEntityDto, EntityDto, ExtensibleEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CarStatus } from '../../cars/car-status.enum';
import type { DealerDto } from '../dealers/models';

export interface BrandDto extends EntityDto<string> {
  name?: string;
  firstLetter?: string;
}

export interface ConfigurationItemDto {
  group?: string;
  name?: string;
  displayName?: string;
}

export interface GetModelsInput {
  brandId: string;
}

export interface GetTrimsInput {
  modelId: string;
}

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

export interface ModelCompanyDto {
  name?: string;
  models: ModelDto[];
}

export interface ModelDto extends EntityDto<string> {
  brand: BrandDto;
  name?: string;
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

export interface TrimDto extends ExtensibleEntityDto<string> {
  model: ModelDto;
  year?: string;
  name?: string;
}

export interface UsedCarDto extends CreationAuditedEntityDto<string> {
  brandId?: string;
  modelId?: string;
  trimId?: string;
  name?: string;
  description?: string;
  status: CarStatus;
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
