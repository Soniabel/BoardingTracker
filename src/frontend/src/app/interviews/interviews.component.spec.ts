import {ComponentFixture, fakeAsync, TestBed, tick} from '@angular/core/testing';
import { InterviewsComponent } from './interviews.component';
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { MatCardModule } from "@angular/material/card";
import { By } from "@angular/platform-browser";
import { InterviewService } from "../services/interview.service";
import { of } from "rxjs";
import { Interview } from "./models/interview";
import { StoreModule } from '@ngrx/store';

describe('InterviewsComponent', () => {
  let component: InterviewsComponent;
  let fixture: ComponentFixture<InterviewsComponent>;
  let interviewService: jasmine.SpyObj<InterviewService>;
  const expectedInterviews: Interview[] =  [
    {
      id: 1,
      title: 'TestTitle',
      startTime: 'StartTime',
      endTime: 'EndTime',
      vacancy: {
        id: 1,
        title: 'TestTitle',
        description: 'TestDescription',
        salary: 1234,
        seniorityLevel: {
          id: 1,
          name: 'TestLevel'
        },
        vacancyType: {
          id: 1,
          name: 'TestType'
        },
        vacancyStatus:{
          id: 1,
          name: 'TestStatus'
        },
        recruiter:{
          id: 1,
          firstName: 'TestFirstName',
          lastName: 'TestLastName',
          profileImageUrl: 'TestImageUrl',
          userId: 1,
          email: 'TestEmail'
        }
      },
      recruiter:{
        id: 1,
        firstName: 'TestFirstName',
        lastName: 'TestLastName',
        profileImageUrl: 'TestImageUrl',
        userId: 1,
        email: 'TestEmail'
      },
      candidate: {
        id: 1,
        firstName: 'TestFirstName',
        lastName: 'TestLastName',
        phoneNumber: '2423424',
        profileImageUrl: 'TestImageUrl',
        biography: 'TestBiography',
        resumeUrl: 'TestResumeUrl',
        email: 'TestEmail'
      },
      interviewType: {
        id: 1,
        name:'TestInterviewType'
      }
    }
  ];

  beforeEach(async () => {
    interviewService = jasmine.createSpyObj('InterviewService', ['getAll']);
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule, MatDialogModule, MatCardModule, StoreModule.forRoot({}) ],
      declarations: [ InterviewsComponent ],
      providers: [{
        provide: InterviewService, useValue: interviewService
      }],
      schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InterviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call openInterviewItem() and interviewDialogContainer.open()', async () => {
    interviewService.getAll.and.returnValue(of(expectedInterviews));

    fixture.detectChanges();
    component.ngOnInit();

    console.log(component.interviews$); // Observable{_subscribe: subscriber => { ... }}
    expect(interviewService.getAll).toHaveBeenCalled() // true

    let button = fixture.debugElement.nativeElement.querySelector('button');
    console.log(button) // null

    let h4 = fixture.debugElement.nativeElement.querySelector('h4');
    console.log(h4) // <h4 _ngcontent-a-c95="" class="interview-title">INTERVIEWS</h4>

    component.interviews$.subscribe(item => item.map((data) => {
      console.log(data) // Object{ id: 1, title: 'TestTitle' ... }
    }));
  });
});
