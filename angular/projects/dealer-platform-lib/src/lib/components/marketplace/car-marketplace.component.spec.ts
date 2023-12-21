import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarMarketplaceComponent } from './car-marketplace.component';

describe('CarMarketplaceComponent', () => {
  let component: CarMarketplaceComponent;
  let fixture: ComponentFixture<CarMarketplaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarMarketplaceComponent]
    });
    fixture = TestBed.createComponent(CarMarketplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
