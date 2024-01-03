import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedCarCreateEditExtractComponent } from './used-car-create-edit-extract.component';

describe('UsedCarCreateEditExtractComponent', () => {
  let component: UsedCarCreateEditExtractComponent;
  let fixture: ComponentFixture<UsedCarCreateEditExtractComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsedCarCreateEditExtractComponent]
    });
    fixture = TestBed.createComponent(UsedCarCreateEditExtractComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
