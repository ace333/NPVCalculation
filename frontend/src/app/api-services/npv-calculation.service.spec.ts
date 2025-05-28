import { TestBed } from '@angular/core/testing';

import { NpvCalculationService } from './npv-calculation.service';

describe('NpvCalculationService', () => {
  let service: NpvCalculationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NpvCalculationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
