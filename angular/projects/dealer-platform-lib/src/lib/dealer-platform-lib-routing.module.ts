import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CarMarketplaceComponent, CarListComponent, CreateComponent, DetailsComponent, ListComponent } from './components';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { IsDealerPlatformService } from './services';



const routes: Routes = [
 {
  path:'',
  canActivate: [IsDealerPlatformService],
  children:[ {
    path: '',
    children: [{
      path: 'info',
      component: CarMarketplaceComponent,
    }, {
      path: 'consultation',
      component: ListComponent,
    }]
  },
  {
    path: 'userd-car',
    children: [
      {
        path: '',
        component: CarListComponent,
      },
      {
        path: 'create',
        component: CreateComponent,
      },
      {
        path: 'details/:id',
        component: DetailsComponent,
      },
      {
        path: ':id/edit',
        component: CreateComponent,
      },
    ]
  },]
 }
];

@NgModule({
  imports: [RouterModule.forChild(routes), CommonModule],
  exports: [RouterModule],
})
export class DealerPlatformLibRoutingModule { }
