/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
/* eslint-disable @angular-eslint/contextual-lifecycle */
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarColorService {

  constructor() { 
  }
  CarColor:any[]=[]
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
   
  }
}
