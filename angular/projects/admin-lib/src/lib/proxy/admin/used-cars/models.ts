import type { CreationAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CarStatus } from '../../cars/car-status.enum';
import type { DealerDto } from '../dealers/models';

export interface GetUsedCarsInput extends PagedAndSortedResultRequestDto {
  usedCarId?: number;
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
  dealer: DealerDto;
}
