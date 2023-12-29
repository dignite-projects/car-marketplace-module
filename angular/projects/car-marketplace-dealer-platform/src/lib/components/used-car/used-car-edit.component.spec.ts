import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarEditComponent } from './used-car-edit.component';

describe('UsedCarEditComponent', () => {
  let component: UsedCarEditComponent;
  let fixture: ComponentFixture<UsedCarEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarEditComponent]
    });
    fixture = TestBed.createComponent(UsedCarEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
