import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { InterviewService } from './interview.service';

describe('InterviewService', () => {
  let service: InterviewService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(InterviewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
