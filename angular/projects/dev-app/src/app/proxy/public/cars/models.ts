import type { EntityDto, ExtensibleEntityDto } from '@abp/ng.core';

export interface BrandDto extends EntityDto<string> {
  name?: string;
  firstLetter?: string;
}

export interface GetModelsInput {
  brandId: string;
}

export interface GetTrimsInput {
  modelId: string;
}

export interface ModelCompanyDto {
  name?: string;
  models: ModelDto[];
}

export interface ModelDto extends EntityDto<string> {
  brand: BrandDto;
  name?: string;
}

export interface TrimConfigItemDto {
  group?: string;
  name?: string;
  displayName?: string;
}

export interface TrimDto extends ExtensibleEntityDto<string> {
  model: ModelDto;
  year?: string;
  name?: string;
}
