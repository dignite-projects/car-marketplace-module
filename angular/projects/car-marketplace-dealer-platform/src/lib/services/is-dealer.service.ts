import { Injectable } from '@angular/core';
// import { DealerService } from 'projects/car-marketplace-dealer-platform/proxy/src/proxy/dealer-platform/dealers';
import { DealerService } from '../../../proxy/src/proxy/dealer-platform/dealers';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
/**判断是否是车商 */
@Injectable({
  providedIn: 'root'
})

export class IsDealerService  implements CanActivate {

  constructor(
    private DealerServiceplatform: DealerService,
  ) { }
  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<any> {
    let info = await this.getCarMarketplace()
    if (!info) {
      alert('当前用户不是二手车商')
      return false
    }
    return true
  }
  /**获取车商信息 */
  getCarMarketplace(): any {
    return new Promise((resolve, rejects) => {
      this.DealerServiceplatform.findByCurrentUser().subscribe(async (res) => {
        resolve(res)
      })
    })

  }
}
