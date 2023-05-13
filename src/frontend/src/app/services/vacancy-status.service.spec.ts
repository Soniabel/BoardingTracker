import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { VacancyStatusService } from './vacancy-status.service';

describe('VacancyStatusService', () => {
  let service: VacancyStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(VacancyStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
