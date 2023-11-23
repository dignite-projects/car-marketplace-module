import { NgModule } from '@angular/core';
import { DynamicLayoutComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { CarMarketplaceComponent } from './components/car-marketplace.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: DynamicLayoutComponent,
    children: [
      {
        path: '',
        component: CarMarketplaceComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CarMarketplaceRoutingModule {}
