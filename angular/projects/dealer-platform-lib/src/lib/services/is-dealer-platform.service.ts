import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { DealerService } from '../proxy/dealer-platform/dealers';

@Injectable({
  providedIn: 'root'
})
export class IsDealerPlatformService implements CanActivate {

  constructor(
    private DealerServiceplatform: DealerService,
  ) { }
  // boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>
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
