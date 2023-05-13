import { ChangeDetectionStrategy, Component, OnInit, Inject } from '@angular/core';
import { Vacancy } from "../models/vacancy";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Skill } from "../../shared/models/skill";
import { Observable } from "rxjs";
import { VacancyService } from "../../services/vacancy.service";

@Component({
  selector: 'app-vacancy-item',
  templateUrl: './vacancy-item.component.html',
  styleUrls: ['./vacancy-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VacancyItemComponent implements OnInit {
  public vacancy!: Vacancy;
  public skills$!: Observable<Skill[]>;

  constructor( @Inject(MAT_DIALOG_DATA) public data: any,
               private vacancyService: VacancyService) { }

  ngOnInit(): void {
    this.vacancy = this.data.vacancy;
    this.skills$ = this.vacancyService.getVacancySkills(this.vacancy.id);
  }
}
