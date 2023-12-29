import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCarMarketplaceDealerPlatfromRouteNames } from '../enums/route-names';

export const CAR_MARKETPLACE_DEALER_PLATFORM_ROUTE_PROVIDERS = [
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
        path: '/dealer-platform/dealer/info',
        name: eCarMarketplaceDealerPlatfromRouteNames.DealerInfo,
        iconClass: 'fa fa-window-maximize',
        layout: eLayoutType.application, 
        order: 3,
        // invisible :testauth(),//在该路由中是否可见
        // requiredPolicy: 'CarMarketplace.Dealer'
      }, {
        path: '/dealer-platform/used-car',
        name: eCarMarketplaceDealerPlatfromRouteNames.UsedCar,
        iconClass: 'fa fa-automobile', 
        layout: eLayoutType.application,
        order: 4,
        // requiredPolicy: 'CarMarketplace.UsedCar'
      }, {
        path: '/dealer-platform/used-car/buy',
        name: eCarMarketplaceDealerPlatfromRouteNames.Consultation,
        iconClass: 'fa fa-file-text-o',
        layout: eLayoutType.application,
        order: 5,
        // requiredPolicy: 'CarMarketplace.Dealer'
      }
    ]);
  };
}
