import { TestBed } from '@angular/core/testing';

import { CarMarketplaceAdminService } from './car-marketplace-admin.service';

describe('CarMarketplaceAdminService', () => {
  let service: CarMarketplaceAdminService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarMarketplaceAdminService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
