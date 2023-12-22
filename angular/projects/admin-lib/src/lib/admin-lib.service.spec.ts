import { TestBed } from '@angular/core/testing';

import { AdminLibService } from './admin-lib.service';

describe('AdminLibService', () => {
  let service: AdminLibService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminLibService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
