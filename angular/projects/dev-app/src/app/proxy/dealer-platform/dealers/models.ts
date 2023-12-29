import type { CreationAuditedEntityDto } from '@abp/ng.core';
import type { AuthenticationStatus } from '../../dealers/authentication-status.enum';

export interface DealerCreateDto extends DealerCreateOrUpdateDtoBase {
}

export interface DealerCreateOrUpdateDtoBase {
  name: string;
  shortName: string;
  address: string;
  contactPerson: string;
  contactNumber: string;
  latitude?: number;
  longitude?: number;
}

export interface DealerDto extends CreationAuditedEntityDto<string> {
  name?: string;
  shortName?: string;
  address?: string;
  contactPerson?: string;
  contactNumber?: string;
  latitude?: number;
  longitude?: number;
  authenticationStatus: AuthenticationStatus;
}

export interface DealerUpdateDto extends DealerCreateOrUpdateDtoBase {
}
