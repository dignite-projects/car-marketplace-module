import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerPlatformLibComponent } from './dealer-platform-lib.component';

describe('DealerPlatformLibComponent', () => {
  let component: DealerPlatformLibComponent;
  let fixture: ComponentFixture<DealerPlatformLibComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerPlatformLibComponent]
    });
    fixture = TestBed.createComponent(DealerPlatformLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
