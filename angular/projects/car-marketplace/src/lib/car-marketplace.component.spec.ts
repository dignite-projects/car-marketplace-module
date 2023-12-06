import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
// import { CarMarketplaceComponent } from './components/car-marketplace.component';
import { CarMarketplaceComponent, CarMarketplaceService } from '@dignite/car-marketplace';
import { of } from 'rxjs';

describe('CarMarketplaceComponent', () => {
  let component: CarMarketplaceComponent;
  let fixture: ComponentFixture<CarMarketplaceComponent>;
  const mockCarMarketplaceService = jasmine.createSpyObj('CarMarketplaceService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CarMarketplaceComponent],
      providers: [
        {
          provide: CarMarketplaceService,
          useValue: mockCarMarketplaceService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarMarketplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
