import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { AuthenticationStatus } from '../../dealers/authentication-status.enum';

export interface DealerDto extends EntityDto<string> {
  name?: string;
  address?: string;
  contactPerson?: string;
  contactNumber?: string;
  latitude?: number;
  longitude?: number;
  authenticationStatus: AuthenticationStatus;
}

export interface GetDealersInput extends PagedAndSortedResultRequestDto {
  filter?: string;
}
