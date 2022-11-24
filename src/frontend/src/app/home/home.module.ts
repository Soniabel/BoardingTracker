import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { TopVacanciesComponent } from './top-vacancies/top-vacancies.component';
import { TopRecruitersComponent } from './top-recruiters/top-recruiters.component';
import { MatCardModule } from '@angular/material/card';
import { HttpClientModule } from "@angular/common/http";
import { MatDialogModule } from "@angular/material/dialog";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [
    HomeComponent,
    TopVacanciesComponent,
    TopRecruitersComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatIconModule,
    RouterLink,
    SharedModule
  ],
  exports: [
    TopVacanciesComponent,
    TopRecruitersComponent
  ]
})
export class HomeModule { }
