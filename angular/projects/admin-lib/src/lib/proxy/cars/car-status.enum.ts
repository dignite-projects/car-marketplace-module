import { mapEnumToOptions } from '@abp/ng.core';

export enum CarStatus {
  Waiting = 0,
  Listing = 1,
  OffShelf = 2,
  Sold = 3,
}

export const carStatusOptions = mapEnumToOptions(CarStatus);
