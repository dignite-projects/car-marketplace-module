import { Injectable } from '@angular/core';
import { carStatusName } from 'projects/car-marketplace/config/src/enums/car-status-name';
import { carStatusOptions } from 'projects/car-marketplace/proxy/cars';
// import { carStatusOptions } from 'projects/car-marketplace/proxy/cars';

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
        console.log('StatusOptions',StatusOptions);
        
        resolve(new Array(...StatusOptions))
      })
  
    }
}
