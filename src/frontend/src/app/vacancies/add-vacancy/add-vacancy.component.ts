import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Recruiter } from 'src/app/recruiters/models/recruiter';
import { RecruiterService } from 'src/app/services/recruiter.service';
import { SeniorityLevelService } from 'src/app/services/seniority-level.service';
import { VacancyStatusService } from 'src/app/services/vacancy-status.service';
import { VacancyTypeService } from 'src/app/services/vacancy-type.service';
import { VacancyService } from 'src/app/services/vacancy.service';
import { SeniorityLevel } from 'src/app/shared/models/seniority-level';
import { VacancyStatus } from '../models/vacancy-status';
import { VacancyType } from '../models/vacancy-type';

@Component({
  selector: 'app-add-vacancy',
  templateUrl: './add-vacancy.component.html',
  styleUrls: ['./add-vacancy.component.scss']
})
export class AddVacancyComponent implements OnInit {
  public seniorityLevels$!: Observable<SeniorityLevel[]>;
  public vacancyTypes$!: Observable<VacancyType[]>;
  public vacancyStatuses$!: Observable<VacancyStatus[]>;
  public recruiters$!: Observable<Recruiter[]>;
  public addVacancyForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private seniorityLevelService: SeniorityLevelService,
              private vacancyTypeService: VacancyTypeService,
              private vacancyService: VacancyService,
              private vacancyStatusService: VacancyStatusService,
              private recruiterService: RecruiterService,
              private router: Router) { }

  ngOnInit(): void {
    this.addVacancyForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      salary: ['', Validators.required],
      seniorityLevelId: ['', Validators.required],
      vacancyTypeId: ['', Validators.required],
      vacancyStatusId: ['', Validators.required],
      recruiterId: ['', Validators.required]
    });

    this.seniorityLevels$ = this.seniorityLevelService.getAll();
    this.vacancyTypes$ = this.vacancyTypeService.getAll();
    this.vacancyStatuses$ = this.vacancyStatusService.getAll();
    this.recruiters$ = this.recruiterService.getAll();
  }

  public addVacancy(): void {
    this.vacancyService.addVacancy(this.addVacancyForm.value).subscribe(result => {
      alert(`Vacancy added`);
      this.router.navigate(['/vacancies']);
    })
  }
}
