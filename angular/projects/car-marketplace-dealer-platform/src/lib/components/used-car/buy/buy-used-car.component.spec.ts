import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyUsedCarComponent } from './buy-used-car.component';

describe('BuyUsedCarComponent', () => {
  let component: BuyUsedCarComponent;
  let fixture: ComponentFixture<BuyUsedCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BuyUsedCarComponent]
    });
    fixture = TestBed.createComponent(BuyUsedCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
