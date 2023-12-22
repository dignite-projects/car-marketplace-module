/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { SaleCarService } from '../../proxy/admin/cars';
// import { SaleCarService } from 'projects/admin-lib/proxy/admin/cars';
// import { SaleCarService } from '../../../../proxy/admin/cars/sale-car.service';


@Component({
  selector: 'lib-sale-car',
  templateUrl: './sale-car.component.html',
  styleUrls: ['./sale-car.component.scss','../../style/index.scss']
})
export class SaleCarComponent {

  constructor(
    private router: Router,
    private message: NzMessageService, 
    private modal: NzModalService,
    private _SaleCarService:SaleCarService
  
  ) { } 

  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
   this.getsaleCarList()
  }

  /**卖车列表 */ 
  saleCarList: any[any] = []
  /**车商列表-分页 */
  skipCount: number = 0
  /**车商列表-每页最大个数 */
  maxResultCount: number = 15
  /**车商列表--总数据 */
  pageTotal: number = 0

  /**获取二手车列表 */
  getsaleCarList() {
    return new Promise<void>((resolve,reject)=>{
      this._SaleCarService.getList({
        skipCount:this.skipCount*this.maxResultCount,
        maxResultCount: this.maxResultCount
      }).subscribe(res=>{
        this.saleCarList=res.items
        this.pageTotal=res.totalCount
        resolve()
      })
      
    })
  
  }



  
  /**翻页 */
  nzPageIndexChange(event) {
    this.skipCount = event - 1
    this.getsaleCarList()
  }
}
