import type { CreationAuditedEntityDto, PagedResultRequestDto } from '@abp/ng.core';
import type { UsedCarDto } from '../cars/models';

export interface GetUsedCarConsultationsInput extends PagedResultRequestDto {
  filter?: string;
}

export interface UsedCarConsultationDto extends CreationAuditedEntityDto<string> {
  usedCarId?: string;
  usedCar: UsedCarDto;
  contactPerson?: string;
  contactNumber?: string;
  reservationTime?: string;
}
