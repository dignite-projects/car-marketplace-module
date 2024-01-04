import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterState } from '@angular/router';
import { SaleUsedCarService } from '../../proxy/admin/used-cars';
import { Observable } from 'rxjs';
// import { SaleUsedCarService } from '../../../../proxy/src/proxy/admin/used-cars';

@Component({
  selector: 'lib-sale-car-detail',
  templateUrl: './sale-car-detail.component.html',
  styleUrls: ['./sale-car-detail.component.scss']
})
export class SaleCarDetailComponent {
  constructor(
    private route: ActivatedRoute,
    // private _SaleCarService: SaleCarService
    private _SaleUsedCarService:SaleUsedCarService
  ) {
  }
  saleCarInfo: any = ''
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
      this._SaleUsedCarService.get(this.saleCarId).subscribe((res: any) => {
        this.saleCarInfo = res
      })
      resolve()
    })
  }

}
