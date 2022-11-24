import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Vacancy } from "./models/vacancy";
import { VacancyService } from "../services/vacancy.service";
import { Observable } from "rxjs";
import { MatDialog } from "@angular/material/dialog";
import { VacancyItemComponent } from "./vacancy-item/vacancy-item.component";

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: ['./vacancies.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VacanciesComponent implements OnInit {
  public vacancies$!: Observable<Vacancy[]>;

  constructor(private vacancyService: VacancyService,
              private vacancyDialogContainer: MatDialog) { }

  ngOnInit(): void {
    this.vacancies$ = this.vacancyService.getAll();
  }

  openVacancyItem(vacancy: Vacancy): void {
    this.vacancyDialogContainer.open(VacancyItemComponent, {
      panelClass: 'vacancy-modal-container',
      width: '40rem',
      data: { vacancy: vacancy }
    });
  }
}
