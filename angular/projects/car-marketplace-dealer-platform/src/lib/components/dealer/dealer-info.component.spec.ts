import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerInfoComponent } from './dealer-info.component';

describe('DealerInfoComponent', () => {
  let component: DealerInfoComponent;
  let fixture: ComponentFixture<DealerInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerInfoComponent]
    });
    fixture = TestBed.createComponent(DealerInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
