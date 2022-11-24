import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { SeniorityLevelService } from './seniority-level.service';

describe('SeniorityLevelService', () => {
  let service: SeniorityLevelService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(SeniorityLevelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
