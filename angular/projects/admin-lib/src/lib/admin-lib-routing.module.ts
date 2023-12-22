import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ManageComponent, SaleCarComponent, SaleCarViewComponent, UsedCarDetailsComponent, UsedCarListComponent } from './components';
const routes: Routes = [
    {
        path: '',
        children: [{
            path: 'manage',
            
            component: ManageComponent,
        },]
    },
    {
        path: 'sale-car',
        children: [{
            path: '',
            component: SaleCarComponent,
        }, {
            path: 'details/:id',
            component: SaleCarViewComponent,
        }]
    },
    {
        path: 'used-car',
        children: [{
            path: '',
            component: UsedCarListComponent,
        }, {
            path: 'details/:id',
            component: UsedCarDetailsComponent,
        }]
    },
];


@NgModule({
    imports: [RouterModule.forChild(routes), CommonModule],
    exports: [RouterModule]
})
export class AdminLibRoutingModule { }
