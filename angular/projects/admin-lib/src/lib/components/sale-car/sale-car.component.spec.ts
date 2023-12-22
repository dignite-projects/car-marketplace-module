import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleCarComponent } from './sale-car.component';

describe('SaleCarComponent', () => {
  let component: SaleCarComponent;
  let fixture: ComponentFixture<SaleCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaleCarComponent]
    });
    fixture = TestBed.createComponent(SaleCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
