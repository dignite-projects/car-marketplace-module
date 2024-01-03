import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarCreateComponent } from './used-car-create.component';

describe('UsedCarCreateComponent', () => {
  let component: UsedCarCreateComponent;
  let fixture: ComponentFixture<UsedCarCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarCreateComponent]
    });
    fixture = TestBed.createComponent(UsedCarCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
