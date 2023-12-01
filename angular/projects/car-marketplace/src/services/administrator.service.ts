import { Injectable } from '@angular/core';
import { AuthenticationStatusToName } from '@dignite/car-marketplace/config';
import { authenticationStatusOptions, AuthenticationStatus } from 'projects/car-marketplace/proxy/dealers';

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
