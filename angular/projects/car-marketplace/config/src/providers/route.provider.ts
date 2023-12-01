import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCarMarketplaceRouteNames } from '../enums/route-names';

export const CAR_MARKETPLACE_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/car-marketplace',
        name: eCarMarketplaceRouteNames.CarMarketplace,
        iconClass: 'calendar',
        layout: eLayoutType.application,
        order: 3,
      }, {
        path: '/car-marketplace/car',
        name: eCarMarketplaceRouteNames.Car,
        iconClass: 'car',
        layout: eLayoutType.application,
        order: 4,
      }, {
        path: '/administrator',
        name: eCarMarketplaceRouteNames.Administrator,
        iconClass: 'dollar',
        layout: eLayoutType.application,
        order: 5,
      }, {
        path: '/administrator/saleCar',
        name: eCarMarketplaceRouteNames.SaleCar,
        iconClass: 'console-sql',
        layout: eLayoutType.application,
        order: 5,
      }
    ]);
  };
}
