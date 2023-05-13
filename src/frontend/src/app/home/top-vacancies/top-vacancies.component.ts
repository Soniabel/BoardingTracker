import { Component } from '@angular/core';

@Component({
  selector: 'app-top-vacancies',
  templateUrl: './top-vacancies.component.html',
  styleUrls: ['./top-vacancies.component.scss']
})
export class TopVacanciesComponent {

  vacancies = 
  [
    {
      title: "Vacancy 1",
      seniorityLevel: "Junior",
      type: "Full Time"
    },
    {
      title: "Vacancy 2",
      seniorityLevel: "Middle",
      type: "Full Time"
    },
    {
      title: "Vacancy 3",
      seniorityLevel: "Junior",
      type: "Part Time"
    }
  ]; 

  constructor() {}
}