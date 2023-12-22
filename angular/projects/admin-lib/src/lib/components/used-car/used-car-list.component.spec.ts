import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarListComponent } from './used-car-list.component';

describe('UsedCarListComponent', () => {
  let component: UsedCarListComponent;
  let fixture: ComponentFixture<UsedCarListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarListComponent]
    });
    fixture = TestBed.createComponent(UsedCarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
