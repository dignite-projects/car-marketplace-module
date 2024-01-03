import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarMarketplaceAdminComponent } from './car-marketplace-admin.component';

describe('CarMarketplaceAdminComponent', () => {
  let component: CarMarketplaceAdminComponent;
  let fixture: ComponentFixture<CarMarketplaceAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarMarketplaceAdminComponent]
    });
    fixture = TestBed.createComponent(CarMarketplaceAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
