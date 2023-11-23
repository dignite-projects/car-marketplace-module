import { TestBed } from '@angular/core/testing';
import { CarMarketplaceService } from './services/car-marketplace.service';
import { RestService } from '@abp/ng.core';

describe('CarMarketplaceService', () => {
  let service: CarMarketplaceService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(CarMarketplaceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
