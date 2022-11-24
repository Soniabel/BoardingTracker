import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VacanciesComponent } from "./vacancies.component";
import { VacancyItemComponent } from "./vacancy-item/vacancy-item.component";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from "../shared/shared.module";
import { ReactiveFormsModule } from "@angular/forms";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { VacanciesRoutingModule } from "./vacancies-routing.module";
import { AddVacancyComponent } from './add-vacancy/add-vacancy.component';

@NgModule({
  declarations: [
    VacanciesComponent,
    VacancyItemComponent,
    AddVacancyComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    SharedModule,
    VacanciesRoutingModule,
    MatMenuModule,
    MatIconModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatInputModule
  ]
})
export class VacanciesModule { }
