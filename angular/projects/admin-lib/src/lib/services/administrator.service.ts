import { Injectable } from '@angular/core';
// import { AuthenticationStatusToName } from '../../config/src/public-api';
import { authenticationStatusOptions } from '../proxy/dealers';
import { AuthenticationStatusToName } from '../enum/AuthenticationStatus-name';
// import { authenticationStatusOptions } from '../../proxy/dealers';

@Injectable({
  providedIn: 'root'
})
export class AdministratorService {

  constructor() {
  }

  /**匹配类型与displayNmae */
  getauthenticationStatusOptions():Promise<unknown> {
    return new Promise((resolve, reject) => {
      let StatusOptions = JSON.parse(JSON.stringify(authenticationStatusOptions))
      StatusOptions.map((el:any) => {
        el.displayName=AuthenticationStatusToName[el.key]
      })
      resolve(new Array(...StatusOptions))
    })

  }

}
