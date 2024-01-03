import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CAR_MARKETPLACE_ADMIN_ROUTE_PROVIDERS } from './public-api';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class CarMarketplaceAdminConfigModule { 
  static forRoot(): ModuleWithProviders<CarMarketplaceAdminConfigModule> {
    return {
      ngModule: CarMarketplaceAdminConfigModule,
      providers: [CAR_MARKETPLACE_ADMIN_ROUTE_PROVIDERS],
    };
  }
}
