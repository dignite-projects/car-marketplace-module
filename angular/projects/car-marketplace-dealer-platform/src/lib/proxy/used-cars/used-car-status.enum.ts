import { mapEnumToOptions } from '@abp/ng.core';

export enum UsedCarStatus {
  Waiting = 0,
  Listing = 1,
  OffShelf = 2,
  Sold = 3,
}

export const usedCarStatusOptions = mapEnumToOptions(UsedCarStatus);
