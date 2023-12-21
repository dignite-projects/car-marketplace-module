import type { CreationAuditedEntityDto, EntityDto, PagedResultRequestDto } from '@abp/ng.core';

export interface BrandDto extends EntityDto<string> {
  name?: string;
  firstLetter?: string;
}

export interface GetSaleCarsInput extends PagedResultRequestDto {
}

export interface ModelDto extends EntityDto<string> {
  brand: BrandDto;
  group?: string;
  name?: string;
}

export interface SaleCarDto extends CreationAuditedEntityDto<string> {
  modelId?: string;
  model: ModelDto;
  description?: string;
  registrationDate?: string;
  totalMileage: number;
  address?: string;
  contactPerson?: string;
  contactNumber?: string;
}
