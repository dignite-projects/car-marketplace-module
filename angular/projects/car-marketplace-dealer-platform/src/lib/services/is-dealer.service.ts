import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot,  } from '@angular/router';
import { Observable } from 'rxjs';
import { DealerService } from '../proxy/dealer-platform/dealers';
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
