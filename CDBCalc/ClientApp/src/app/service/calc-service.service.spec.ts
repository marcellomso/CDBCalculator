import { TestBed } from '@angular/core/testing';

import { CalcService } from './calc-service.service';

describe('CalcServiceService', () => {
  let service: CalcService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalcService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
