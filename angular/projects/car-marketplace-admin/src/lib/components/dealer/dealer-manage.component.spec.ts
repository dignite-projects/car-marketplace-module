import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerManageComponent } from './dealer-manage.component';

describe('DealerManageComponent', () => {
  let component: DealerManageComponent;
  let fixture: ComponentFixture<DealerManageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerManageComponent]
    });
    fixture = TestBed.createComponent(DealerManageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
