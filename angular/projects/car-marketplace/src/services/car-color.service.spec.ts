import { TestBed } from '@angular/core/testing';

import { CarColorService } from './car-color.service';

describe('CarColorService', () => {
  let service: CarColorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarColorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
