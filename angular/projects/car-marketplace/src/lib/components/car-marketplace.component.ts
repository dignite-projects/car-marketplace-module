import { Component, OnInit } from '@angular/core';
import { CarMarketplaceService } from '../services/car-marketplace.service';

@Component({
  selector: 'lib-car-marketplace',
  template: ` <p>car-marketplace works!</p> `,
  styles: [],
})
export class CarMarketplaceComponent implements OnInit {
  constructor(private service: CarMarketplaceService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
