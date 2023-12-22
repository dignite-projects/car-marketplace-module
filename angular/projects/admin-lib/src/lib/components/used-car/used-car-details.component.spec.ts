import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarDetailsComponent } from './used-car-details.component';

describe('UsedCarDetailsComponent', () => {
  let component: UsedCarDetailsComponent;
  let fixture: ComponentFixture<UsedCarDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarDetailsComponent]
    });
    fixture = TestBed.createComponent(UsedCarDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
