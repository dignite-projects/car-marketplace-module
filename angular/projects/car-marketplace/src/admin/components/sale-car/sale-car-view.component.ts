/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SaleCarService } from 'projects/car-marketplace/proxy/admin/cars';

@Component({
  selector: 'lib-sale-car-view',
  templateUrl: './sale-car-view.component.html',
  styleUrls: ['./sale-car-view.component.scss', '.../../../../../style/index.scss']
})
export class SaleCarViewComponent {

  constructor(
    private route: ActivatedRoute,
    private _SaleCarService: SaleCarService
  ) {

  }
  saleCarDetail: any = ''
  saleCarId: any = ''

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.route.queryParams.subscribe(async (params) => {
      console.log(params, '跳转页面接收数据');
      if (params.saleCarId) {
        this.saleCarId = params.saleCarId
        this.getsaleCar()
      }
    })
  }

  getsaleCar() {
    return new Promise<void>((resolve, reject) => {
      this._SaleCarService.get(this.saleCarId).subscribe(res => {
        this.saleCarDetail = res
      })

      resolve()
    })
  }



}
