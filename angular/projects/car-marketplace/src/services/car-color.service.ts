/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
/* eslint-disable @angular-eslint/contextual-lifecycle */
import { Injectable } from '@angular/core';
import { CarColor, CarColorOptions } from 'projects/car-marketplace/config/src/enums/car-color';

@Injectable({
  providedIn: 'root'
})
export class CarColorService {

  constructor() { 
    // for(let item in CarColor){
      console.log(CarColorOptions,'1222222');
      
      
    // }
    
  }
  CarColor:any[]=[]
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
   
  }
}
