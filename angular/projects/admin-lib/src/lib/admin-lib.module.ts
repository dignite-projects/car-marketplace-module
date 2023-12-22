import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { AdminLibComponent } from './admin-lib.component';
import { AdminLibRoutingModule } from './admin-lib-routing.module';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ManageComponent, SaleCarComponent, SaleCarViewComponent, UsedCarListComponent, UsedCarDetailsComponent } from './components';
import { Zorro } from './import';
import { DateTPipe } from './pipe';



@NgModule({
  declarations: [
    AdminLibComponent,
    ManageComponent,
    SaleCarComponent,
    DateTPipe, 
    SaleCarViewComponent, 
    UsedCarListComponent, 
    UsedCarDetailsComponent
  ],
  imports:[CoreModule, ThemeSharedModule, AdminLibRoutingModule,Zorro],
  exports: [AdminLibComponent],
  providers: [ ],
})
export class AdminLibModule {
  static forChild(): ModuleWithProviders<AdminLibModule> {
    return {
      ngModule: AdminLibRoutingModule,
      providers: [],
    };
  }
  static forLazy(): NgModuleFactory<AdminLibModule> { 
    return new LazyModuleFactory(AdminLibModule.forChild());
  }
 }
