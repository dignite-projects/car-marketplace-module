import {  ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { CarMarketplaceDealerPlatformComponent } from './car-marketplace-dealer-platform.component';
import { CarMarketplaceDealerPlatformRoutingModule } from './car-marketplace-dealer-platform-routing.module';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import {
  UsedCarComponent,
  UsedCarDetailComponent,
  UsedCarCreateComponent,
  UsedCarEditComponent,
  DealerInfoComponent,
  BuyUsedCarComponent
} from './components';
// import { ComponentsModule } from '../../../components/src/public-api'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import {
  GetDealerStatusToNamePipe,
  DateTPipe,
  GetUsedCarStatusToNamePipe
} from './pipes';
import {
  NgbToastModule,
  NgbDropdownModule,
  NgbDatepickerModule,
  NgbDateAdapter,
  NgbDateNativeUTCAdapter,
} from '@ng-bootstrap/ng-bootstrap';
import { UsedCarCreateEditExtractComponent } from './components/used-car/used-car-create-edit-extract/used-car-create-edit-extract.component';
import { ComponentsModule } from '@dignite/components';





@NgModule({
  declarations: [
    CarMarketplaceDealerPlatformComponent,
    DealerInfoComponent,
    UsedCarComponent,
    UsedCarDetailComponent,
    UsedCarCreateComponent,
    UsedCarEditComponent,
    GetDealerStatusToNamePipe,
    DateTPipe,
    GetUsedCarStatusToNamePipe,
    BuyUsedCarComponent,
    UsedCarCreateEditExtractComponent,
  ],
  imports: [
    CoreModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ComponentsModule,
    CarMarketplaceDealerPlatformRoutingModule,
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

  ],
  providers: [
    { provide: NgbDateAdapter, useClass: NgbDateNativeUTCAdapter },
  ],
  exports: [

  ]
})
export class CarMarketplaceDealerPlatformModule {
  static forChild(): ModuleWithProviders<CarMarketplaceDealerPlatformModule> {
    return {
      ngModule: CarMarketplaceDealerPlatformModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CarMarketplaceDealerPlatformModule> {
    return new LazyModuleFactory(CarMarketplaceDealerPlatformModule.forChild());
  }
}
