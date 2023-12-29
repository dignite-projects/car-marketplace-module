import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarMarketplaceDealerPlatformComponent } from './car-marketplace-dealer-platform.component';

describe('CarMarketplaceDealerPlatformComponent', () => {
  let component: CarMarketplaceDealerPlatformComponent;
  let fixture: ComponentFixture<CarMarketplaceDealerPlatformComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarMarketplaceDealerPlatformComponent]
    });
    fixture = TestBed.createComponent(CarMarketplaceDealerPlatformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
