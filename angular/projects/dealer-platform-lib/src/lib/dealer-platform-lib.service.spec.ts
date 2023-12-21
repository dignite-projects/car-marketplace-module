import { TestBed } from '@angular/core/testing';

import { DealerPlatformLibService } from './dealer-platform-lib.service';

describe('DealerPlatformLibService', () => {
  let service: DealerPlatformLibService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DealerPlatformLibService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
