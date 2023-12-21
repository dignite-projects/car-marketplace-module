import { ModuleWithProviders, NgModule, NgModuleFactory } from '@angular/core';
import { DealerPlatformLibComponent } from './dealer-platform-lib.component';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CarMarketplaceComponent, CarListComponent, CreateComponent, DetailsComponent, ListComponent } from './components';
import { Zorro } from './import';
import { DateTPipe } from './pipe';
import { DealerPlatformLibRoutingModule } from './dealer-platform-lib-routing.module';



@NgModule({
  // declarations: [
  //   DealerPlatformLibComponent
  // ],
  // imports: [
  // ],
  // exports: [
  //   DealerPlatformLibComponent
  // ]
  declarations: [DealerPlatformLibComponent,CarMarketplaceComponent, DateTPipe, CarListComponent, CreateComponent, DetailsComponent, ListComponent],
  imports: [CoreModule, ThemeSharedModule, Zorro, DealerPlatformLibRoutingModule],
  exports: [DealerPlatformLibComponent],
})
export class DealerPlatformLibModule { 
  static forChild(): ModuleWithProviders<DealerPlatformLibModule> {
    return {
      ngModule: DealerPlatformLibModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<DealerPlatformLibModule> {
    return new LazyModuleFactory(DealerPlatformLibModule.forChild());
  }
}
