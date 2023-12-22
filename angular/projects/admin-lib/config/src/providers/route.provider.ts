import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCarAdminRouteNames } from '../enums/route-names';

export const ADMIN_LIB_ROUTE_PROVIDERS = [
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
        path: '/admin/manage',
        name: eCarAdminRouteNames.Administrator,
        iconClass: 'fa fa-gears',
        layout: eLayoutType.application, 
        order: 6,
        requiredPolicy:'CarMarketplace.Dealer.Management'
      }, {
        path: '/admin/sale-car',
        name: eCarAdminRouteNames.SaleCar, 
        iconClass: 'fa fa-btc ',
        layout: eLayoutType.application,
        order: 7,
        requiredPolicy: 'CarMarketplace.SaleCar.Management'
      },
      {
        path: '/admin/used-car',
        name: eCarAdminRouteNames.UsedCarList, 
        iconClass: 'fa fa-taxi',
        layout: eLayoutType.application,
        order: 7,
        requiredPolicy: 'CarMarketplace.UsedCar.Management'
      }

    ]);
  };
}
