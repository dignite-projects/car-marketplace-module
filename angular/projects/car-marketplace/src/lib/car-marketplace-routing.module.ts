import { NgModule } from '@angular/core';
import { DynamicLayoutComponent } from '@abp/ng.core';
import { Routes, RouterModule } from '@angular/router';
import { CarMarketplaceComponent } from './components/marketplace/car-marketplace.component';
import { CarListComponent } from './components/car/car-list.component';
import { CreateComponent } from './components/car/create.component';
import { DetailsComponent } from './components/car/details.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    // component: DynamicLayoutComponent,
    children: [
      {
        path: '',
        component: CarMarketplaceComponent,
      },

    ],
  },
  {
    path: 'car',
    component: CarListComponent,
  },
  {
    path: 'car/create',
    component: CreateComponent,
  },
  {
    path: 'car/details',
    component: DetailsComponent,
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CarMarketplaceRoutingModule { }
