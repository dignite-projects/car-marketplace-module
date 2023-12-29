import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import {
  DealerManageComponent,
  SaleCarComponent,
  SaleCarDetailComponent,
  UsedCarComponent,
  UsedCarDetailComponent,
} from './components';

const routes: Routes = [
  {
    path: 'dealer',
    children: [
      {
        path: 'manage',
        component: DealerManageComponent,
      },
    ],
  },
  {
    path: 'used-car',
    children: [
      {
        path: 'sale-car',
        children: [
          {
            path: '',
            component: SaleCarComponent,
          },
          {
            path: 'details/:id',
            component: SaleCarDetailComponent,
          },
        ],
      },
      {
        path: '',
        component: UsedCarComponent,
      },
      {
        path: 'details/:id',
        component: UsedCarDetailComponent,
      },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes), CommonModule],
  exports: [RouterModule],
})
export class CarMarketplaceAdminRoutingModule {}
