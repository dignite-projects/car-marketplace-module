import { Injectable } from '@angular/core';
import { carStatusName } from '../enum/car-status-name';
import { carStatusOptions } from '../proxy/cars';
// import { carStatusOptions } from '../../proxy/cars';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor() { }

    /**匹配类型与displayNmae */
    getcarStatusName():Promise<unknown> {
      return new Promise((resolve, reject) => {
        let StatusOptions = JSON.parse(JSON.stringify(carStatusOptions))
        StatusOptions.map((el:any) => {
          el.displayName=carStatusName[el.key]
        })
        resolve(new Array(...StatusOptions))
      })
  
    }
}
