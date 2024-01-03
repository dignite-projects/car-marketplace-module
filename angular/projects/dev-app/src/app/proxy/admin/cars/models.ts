import type { EntityDto } from '@abp/ng.core';

export interface BrandDto extends EntityDto<string> {
  name?: string;
  firstLetter?: string;
}

export interface ModelDto extends EntityDto<string> {
  brand: BrandDto;
  group?: string;
  name?: string;
}
