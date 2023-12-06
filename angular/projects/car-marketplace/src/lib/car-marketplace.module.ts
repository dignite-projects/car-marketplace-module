import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CarMarketplaceRoutingModule } from './car-marketplace-routing.module';
import { Zorro } from 'projects/car-marketplace/import';
import { CarMarketplaceComponent } from './components/marketplace/car-marketplace.component';
import { CarListComponent } from './components/car/car-list.component';
import { DateTPipe } from './pipe/date-t.pipe';
import { CreateComponent } from './components/car/create.component';
import { DetailsComponent } from './components/car/details.component';
import { ListComponent } from './components/consultation/list.component';

@NgModule({
  declarations: [CarMarketplaceComponent, DateTPipe, CarListComponent, CreateComponent, DetailsComponent, ListComponent],
  imports: [CoreModule, ThemeSharedModule, CarMarketplaceRoutingModule, Zorro],
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
