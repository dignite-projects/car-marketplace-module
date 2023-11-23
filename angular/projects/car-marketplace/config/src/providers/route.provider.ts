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
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 3,
      },
    ]);
  };
}
