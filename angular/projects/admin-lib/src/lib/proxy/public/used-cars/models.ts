import type { CreationAuditedEntityDto } from '@abp/ng.core';

export interface UsedCarConsultationCreateDto {
  usedCarId: string;
  contactPerson: string;
  contactNumber: string;
  reservationTime: string;
}

export interface UsedCarConsultationDto extends CreationAuditedEntityDto<string> {
  usedCarId?: string;
  contactPerson?: string;
  contactNumber?: string;
  reservationTime?: string;
}
