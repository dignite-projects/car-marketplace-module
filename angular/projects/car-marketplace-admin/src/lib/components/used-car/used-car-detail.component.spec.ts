import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarDetailComponent } from './used-car-detail.component';

describe('UsedCarDetailComponent', () => {
  let component: UsedCarDetailComponent;
  let fixture: ComponentFixture<UsedCarDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarDetailComponent]
    });
    fixture = TestBed.createComponent(UsedCarDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
