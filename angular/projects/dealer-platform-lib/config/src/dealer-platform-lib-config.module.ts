import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DEALER_PLATFORM_LIB_ROUTE_PROVIDERS } from './providers';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class DealerPlatformLibConfigModule {
  static forRoot(): ModuleWithProviders<DealerPlatformLibConfigModule> {
    return {
      ngModule: DealerPlatformLibConfigModule,
      providers: [DEALER_PLATFORM_LIB_ROUTE_PROVIDERS],
    };
  }
 }
