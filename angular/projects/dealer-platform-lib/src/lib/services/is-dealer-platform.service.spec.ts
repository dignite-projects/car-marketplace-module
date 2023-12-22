import { TestBed } from '@angular/core/testing';

import { IsDealerPlatformService } from './is-dealer-platform.service';

describe('IsDealerPlatformService', () => {
  let service: IsDealerPlatformService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IsDealerPlatformService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
