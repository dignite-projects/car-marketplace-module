import { TestBed } from '@angular/core/testing';

import { IsDealerService } from './is-dealer.service';

describe('IsDealerService', () => {
  let service: IsDealerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IsDealerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
