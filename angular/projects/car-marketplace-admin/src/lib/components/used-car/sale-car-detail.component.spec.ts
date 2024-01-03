import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleCarDetailComponent } from './sale-car-detail.component';

describe('SaleCarDetailComponent', () => {
  let component: SaleCarDetailComponent;
  let fixture: ComponentFixture<SaleCarDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaleCarDetailComponent]
    });
    fixture = TestBed.createComponent(SaleCarDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
