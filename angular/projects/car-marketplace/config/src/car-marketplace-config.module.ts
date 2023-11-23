import { ModuleWithProviders, NgModule } from '@angular/core';
import { CAR_MARKETPLACE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CarMarketplaceConfigModule {
  static forRoot(): ModuleWithProviders<CarMarketplaceConfigModule> {
    return {
      ngModule: CarMarketplaceConfigModule,
      providers: [CAR_MARKETPLACE_ROUTE_PROVIDERS],
    };
  }
}
