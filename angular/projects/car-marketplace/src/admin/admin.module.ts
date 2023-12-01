import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ManageComponent } from './components/manage/manage.component';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { Zorro } from 'projects/car-marketplace/import';
import { SaleCarComponent } from './components/sale-car/sale-car.component';
import { SaleCarViewComponent } from './components/sale-car/sale-car-view.component';
import { DateTPipe } from './pipe/date-t.pipe';


@NgModule({
  declarations: [
    ManageComponent,
    SaleCarComponent,
    DateTPipe,
    SaleCarViewComponent
  ],
  imports: [CoreModule, ThemeSharedModule, AdminRoutingModule,Zorro],
})
export class AdminModule { 

  static forChild(): ModuleWithProviders<AdminModule> {
    return {
      ngModule: AdminModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AdminModule> {
    return new LazyModuleFactory(AdminModule.forChild());
  }
}
