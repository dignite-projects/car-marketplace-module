import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarComponent } from './used-car.component';

describe('UsedCarComponent', () => {
  let component: UsedCarComponent;
  let fixture: ComponentFixture<UsedCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarComponent]
    });
    fixture = TestBed.createComponent(UsedCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
