import { mapEnumToOptions } from '@abp/ng.core';

export enum AuthenticationStatus {
  Waiting = 0,
  Approved = 1,
  Disapproved = 2,
  Cancelled = 3,
}

export const authenticationStatusOptions = mapEnumToOptions(AuthenticationStatus);
