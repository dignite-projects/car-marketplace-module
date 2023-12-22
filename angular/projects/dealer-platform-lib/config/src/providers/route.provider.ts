import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCarMarketplaceRouteNames } from '../enums/route-names';

export const DEALER_PLATFORM_LIB_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService], 
    multi: true,
  },
];
function testauth(){
  console.log(1111111,'testauth');
  return false
}

export function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/dealer-platform/info',
        name: eCarMarketplaceRouteNames.CarMarketplace,
        iconClass: 'fa fa-window-maximize',
        layout: eLayoutType.application, 
        order: 3,
        // invisible :testauth(),//在该路由中是否可见
        // requiredPolicy: 'CarMarketplace.Dealer'
      }, {
        path: '/dealer-platform/userd-car',
        name: eCarMarketplaceRouteNames.Car,
        iconClass: 'fa fa-automobile', 
        layout: eLayoutType.application,
        order: 4,
        // requiredPolicy: 'CarMarketplace.UsedCar'
      }, {
        path: '/dealer-platform/consultation',
        name: eCarMarketplaceRouteNames.Consultation,
        iconClass: 'fa fa-file-text-o',
        layout: eLayoutType.application,
        order: 5,
        // requiredPolicy: 'CarMarketplace.Dealer'
      }
    ]);
  };
}
