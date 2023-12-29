import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CAR_MARKETPLACE_DEALER_PLATFORM_ROUTE_PROVIDERS } from './providers/route.provider';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class CarMarketplaceDealerPlatformConfigModule {
  static forRoot(): ModuleWithProviders<CarMarketplaceDealerPlatformConfigModule> {
    return {
      ngModule: CarMarketplaceDealerPlatformConfigModule,
      providers: [CAR_MARKETPLACE_DEALER_PLATFORM_ROUTE_PROVIDERS],
    };
  }
 }
