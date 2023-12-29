import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { CarMarketplaceAdminComponent } from './car-marketplace-admin.component';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ComponentsModule } from '@dignite/components';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CarMarketplaceAdminRoutingModule } from './car-marketplace-admin-routing.module';
import { DealerManageComponent, SaleCarComponent, SaleCarDetailComponent, UsedCarComponent, UsedCarDetailComponent } from './components';
import { DDatePipe, GetDealerStatusNamePipe } from './pipes';
import {
  NgbToastModule,
  NgbDropdownModule,
  NgbDatepickerModule,
  NgbDateAdapter,
  NgbDateNativeUTCAdapter,
} from '@ng-bootstrap/ng-bootstrap';
import { GetUsedCarStatusToNamePipe } from './pipes/get-used-car-status-to-name.pipe';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzImageService } from 'ng-zorro-antd/image';

@NgModule({
  declarations: [
    CarMarketplaceAdminComponent,
    DealerManageComponent,
    SaleCarComponent,
    SaleCarDetailComponent,
    UsedCarComponent,
    UsedCarDetailComponent,
    GetDealerStatusNamePipe,
    DDatePipe,
    GetUsedCarStatusToNamePipe,

  ],
  imports: [
    CoreModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    CarMarketplaceAdminRoutingModule,
    ComponentsModule,
    NzMessageModule,
    NgxDatatableModule.forRoot({
      messages: {
        emptyMessage: 'No data to display', // Message to show when array is presented, but contains no values
        totalMessage: 'total', // Footer total message
        selectedMessage: 'selected' // Footer selected message
      }
    }),
    NgbToastModule,
    NgbDropdownModule,
    NgbDatepickerModule,
    NzModalModule

  ],
  providers: [NzImageService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeUTCAdapter },
  ],
  exports: [
    // CarMarketplaceAdminComponent
  ]
})
export class CarMarketplaceAdminModule {
  static forChild(): ModuleWithProviders<CarMarketplaceAdminModule> {
    return {
      ngModule: CarMarketplaceAdminRoutingModule,
      providers: [],
    };
  }
  static forLazy(): NgModuleFactory<CarMarketplaceAdminModule> {
    return new LazyModuleFactory(CarMarketplaceAdminModule.forChild());
  }

}
