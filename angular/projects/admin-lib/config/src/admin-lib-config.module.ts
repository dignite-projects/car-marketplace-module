import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ADMIN_LIB_ROUTE_PROVIDERS } from './providers';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AdminLibConfigModule { 
  static forRoot(): ModuleWithProviders<AdminLibConfigModule> {
    return {
      ngModule: AdminLibConfigModule,
      providers: [ADMIN_LIB_ROUTE_PROVIDERS],
    };
  }
}
