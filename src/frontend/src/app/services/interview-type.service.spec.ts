import { TestBed } from '@angular/core/testing';
import { InterviewTypeService } from './interview-type.service';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { environment } from "../../environments/environment";
import { HttpErrorResponse } from "@angular/common/http";

describe('InterviewTypeService', () => {
  let service: InterviewTypeService;
  let httpTestingController: HttpTestingController

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      providers: [ InterviewTypeService ]
    })
    service = TestBed.inject(InterviewTypeService)
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected interviewTypes', () => {
    const expectedInterviewTypes =  [
      {
        id: 1,
        name: 'TestFirstName'
      },
      {
        id: 2,
        name: 'TestSecondName'
      }
    ];

    service.getAll().subscribe((interviewTypes) => {
      expect(interviewTypes).toEqual(expectedInterviewTypes);
    })

    const req = httpTestingController.expectOne(`${environment.baseUrl}/interviewtypes`);
    expect(req.request.method).toBe('GET');
    req.flush({ items: expectedInterviewTypes });
  });

  it('should return an error when the server returns a 404', () => {
    const message = 'Not Found'

    service.getAll().subscribe(
      (response) => fail('should fail with the 404 error'),
      (err: HttpErrorResponse) => {
        expect(err.status).toBe(404, 'status')
        expect(err.error).toBe(message, 'message')
      }
    );

    const req = httpTestingController.expectOne(`${environment.baseUrl}/interviewtypes`)
    expect(req.request.method).toBe('GET')
    req.flush(message, {
      status: 404,
      statusText: 'Unauthorized',
    });
  })

  afterEach(() => httpTestingController.verify());
});
