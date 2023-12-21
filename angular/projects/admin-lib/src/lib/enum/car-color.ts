

import { mapEnumToOptions } from '@abp/ng.core';

export enum CarColor {
    黑色, 白色, 红色, 蓝色, 黄色, 紫色, 绿色, 灰色, 粉色, 棕色
}

export const CarColorOptions = mapEnumToOptions(CarColor);
