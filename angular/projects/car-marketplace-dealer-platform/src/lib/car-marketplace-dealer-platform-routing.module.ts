import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { BuyUsedCarComponent, DealerInfoComponent, UsedCarComponent, UsedCarCreateComponent, UsedCarDetailComponent, UsedCarEditComponent } from './components';
import { IsDealerService } from './services';



const routes: Routes = [
  {
    path: 'dealer',
    canActivate:[IsDealerService],
    children: [{
      path: 'info',
      component: DealerInfoComponent
    }]
  },
  {
    path: 'used-car',
    canActivate:[IsDealerService],
    children: [
      {
        path: '',
        component: UsedCarComponent
      },

      {
        path: 'create',
        component: UsedCarCreateComponent,
      },
      {
        path: 'details/:id',
        component: UsedCarDetailComponent,
      },
      {
        path: ':id/edit',
        component: UsedCarEditComponent,
      },
      {
        path: 'buy',
        component: BuyUsedCarComponent
      },
    ]
  }
  // {
  //  path:'',
  //  canActivate: [IsDealerPlatformService],
  //  children:[ {
  //    path: '',
  //    children: [{
  //      path: 'info',
  //      component: CarMarketplaceComponent,
  //    }, {
  //      path: 'consultation',
  //      component: ListComponent,
  //    }]
  //  },
  //  {
  //    path: 'userd-car',
  //    children: [
  //      {
  //        path: '',
  //        component: CarListComponent,
  //      },
  //      {
  //        path: 'create',
  //        component: CreateComponent,
  //      },
  //      {
  //        path: 'details/:id',
  //        component: DetailsComponent,
  //      },
  //      {
  //        path: ':id/edit',
  //        component: CreateComponent,
  //      },
  //    ]
  //  },]
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes), CommonModule],
  exports: [RouterModule],
})
export class CarMarketplaceDealerPlatformRoutingModule { }
