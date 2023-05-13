import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Observable } from "rxjs";
import { Candidate } from "../../candidates/models/candidate";
import { CandidateService } from "../../services/candidate.service";
import { InterviewService } from "../../services/interview.service";
import { VacancyService } from "../../services/vacancy.service";
import { RecruiterService } from "../../services/recruiter.service";
import { Vacancy } from "../../vacancies/models/vacancy";
import { Recruiter } from "../../recruiters/models/recruiter";
import { InterviewTypeService } from "../../services/interview-type.service";
import { InterviewType } from "../models/interview-type";
import { Router } from "@angular/router";

@Component({
  selector: 'app-add-interview',
  templateUrl: './add-interview.component.html',
  styleUrls: ['./add-interview.component.scss']
})
export class AddInterviewComponent implements OnInit {
  public candidates$!: Observable<Candidate[]>;
  public vacancies$!: Observable<Vacancy[]>;
  public recruiters$!: Observable<Recruiter[]>;
  public interviewTypes$!: Observable<InterviewType[]>;
  public vacancyState!: any;
  public addInterviewForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private candidateService: CandidateService,
              private vacancyService: VacancyService,
              private recruiterService: RecruiterService,
              private interviewService: InterviewService,
              private interviewTypeService: InterviewTypeService,
              private router: Router) {
    this.vacancyState = this.router.getCurrentNavigation()?.extras.state;
  }

  ngOnInit(): void {
    this.addInterviewForm = this.formBuilder.group({
      title: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      vacancyId: this.vacancyState ? [this.vacancyState.vacancy.id, Validators.required] : ['', Validators.required],
      recruiterId: this.vacancyState ? [this.vacancyState.vacancy.recruiter.id, Validators.required] : ['', Validators.required],
      candidateId: ['', Validators.required],
      interviewTypeId: ['', Validators.required]
    });

    this.candidates$ = this.candidateService.getAll();
    this.vacancies$ = this.vacancyService.getAll();
    this.recruiters$ = this.recruiterService.getAll();
    this.interviewTypes$ = this.interviewTypeService.getAll();
  }

  public addInterview(): void {
    this.interviewService.addInterview(this.addInterviewForm.value).subscribe(result => {
      alert(`Interview added`);
      this.router.navigate(['/interviews']);
    })
  }
}
