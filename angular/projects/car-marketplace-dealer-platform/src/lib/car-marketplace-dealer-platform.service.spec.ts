import { TestBed } from '@angular/core/testing';

import { CarMarketplaceDealerPlatformService } from './car-marketplace-dealer-platform.service';

describe('CarMarketplaceDealerPlatformService', () => {
  let service: CarMarketplaceDealerPlatformService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarMarketplaceDealerPlatformService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
