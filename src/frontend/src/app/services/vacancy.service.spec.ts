import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { VacancyService } from './vacancy.service';

describe('VacancyService', () => {
  let service: VacancyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(VacancyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

});
