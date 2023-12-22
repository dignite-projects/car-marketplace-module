/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SaleCarService } from '../../proxy/admin/cars';

@Component({
  selector: 'lib-sale-car-view',
  templateUrl: './sale-car-view.component.html',
  styleUrls: ['./sale-car-view.component.scss', '../../style/index.scss']
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
    let saleCarId=this.route.snapshot.params.id
    if (saleCarId) {
      this.saleCarId = saleCarId
      this.getsaleCar()
    }
  }

  getsaleCar() {
    return new Promise<void>((resolve, reject) => {
      this._SaleCarService.get(this.saleCarId).subscribe((res: any) => {
        this.saleCarDetail = res
      })
      resolve()
    })
  }



}
