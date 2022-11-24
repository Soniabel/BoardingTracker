import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewItemComponent } from './interview-item.component';

describe('InterviewItemComponent', () => {
  let component: InterviewItemComponent;
  let fixture: ComponentFixture<InterviewItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InterviewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
