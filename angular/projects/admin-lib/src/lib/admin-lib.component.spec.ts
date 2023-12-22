import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLibComponent } from './admin-lib.component';

describe('AdminLibComponent', () => {
  let component: AdminLibComponent;
  let fixture: ComponentFixture<AdminLibComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminLibComponent]
    });
    fixture = TestBed.createComponent(AdminLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
