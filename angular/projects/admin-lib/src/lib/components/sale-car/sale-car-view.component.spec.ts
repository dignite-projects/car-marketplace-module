import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleCarViewComponent } from './sale-car-view.component';

describe('SaleCarViewComponent', () => {
  let component: SaleCarViewComponent;
  let fixture: ComponentFixture<SaleCarViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SaleCarViewComponent]
    });
    fixture = TestBed.createComponent(SaleCarViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
