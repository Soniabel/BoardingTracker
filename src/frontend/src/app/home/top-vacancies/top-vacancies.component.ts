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
      title: ".NET Developer",
      seniorityLevel: "Junior",
      type: "Full Time"
    },
    {
      title: "Tester",
      seniorityLevel: "Middle",
      type: "Full Time"
    },
    {
      title: "Java Developer",
      seniorityLevel: "Junior",
      type: "Part Time"
    }
  ]; 

  constructor() {}
}