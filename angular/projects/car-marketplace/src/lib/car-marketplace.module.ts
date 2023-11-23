import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CarMarketplaceComponent } from './components/car-marketplace.component';
import { CarMarketplaceRoutingModule } from './car-marketplace-routing.module';

@NgModule({
  declarations: [CarMarketplaceComponent],
  imports: [CoreModule, ThemeSharedModule, CarMarketplaceRoutingModule],
  exports: [CarMarketplaceComponent],
})
export class CarMarketplaceModule {
  static forChild(): ModuleWithProviders<CarMarketplaceModule> {
    return {
      ngModule: CarMarketplaceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CarMarketplaceModule> {
    return new LazyModuleFactory(CarMarketplaceModule.forChild());
  }
}
