import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageComponent } from './components/manage/manage.component';
import { SaleCarComponent } from './components/sale-car/sale-car.component';
import { SaleCarViewComponent } from './components/sale-car/sale-car-view.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    // component: DynamicLayoutComponent,
    children: [
      {
        path: '',
        component: ManageComponent,
      },
    ],
  },
  {
    path: 'saleCar',
    component: SaleCarComponent,
  },
  {
    path: 'view',
    component: SaleCarViewComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
