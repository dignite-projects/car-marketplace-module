import { mapEnumToOptions } from '@abp/ng.core';

export enum DirectoryMovePosition {
  Inside = 0,
  Bottom = 1,
}

export const directoryMovePositionOptions = mapEnumToOptions(DirectoryMovePosition);
