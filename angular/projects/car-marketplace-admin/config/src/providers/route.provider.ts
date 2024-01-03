import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eCarMarketplaceAdminRouteNames } from '../enums/route-names';

export const CAR_MARKETPLACE_ADMIN_ROUTE_PROVIDERS = [
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
                path: '/car-marketplace/dealer/manage',
                name: eCarMarketplaceAdminRouteNames.DealerManage,
                iconClass: 'fa fa-gears',
                layout: eLayoutType.application,
                order: 6,
                requiredPolicy: 'CarMarketplace.Dealer.Management'
            }, {
                path: '/car-marketplace/used-car/sale-car',
                name: eCarMarketplaceAdminRouteNames.SaleCarInfo,
                iconClass: 'fa fa-btc ',
                layout: eLayoutType.application,
                order: 8,
                requiredPolicy: 'CarMarketplace.SaleCar.Management'
            },
            {
                path: '/car-marketplace/used-car/manage',
                name: eCarMarketplaceAdminRouteNames.UsedCarManage,
                iconClass: 'fa fa-taxi',
                layout: eLayoutType.application,
                order: 7,
                requiredPolicy: 'CarMarketplace.UsedCar.Management'
            }

        ]);
    };
}
