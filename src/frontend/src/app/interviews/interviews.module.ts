import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InterviewsComponent } from "./interviews.component";
import { InterviewItemComponent } from "./interview-item/interview-item.component";
import { MatIconModule } from "@angular/material/icon";
import { RouterLink } from "@angular/router";
import { MatCardModule } from "@angular/material/card";
import { HomeModule } from "../home/home.module";
import { MatButtonModule } from "@angular/material/button";
import { AddInterviewComponent } from "./add-interview/add-interview.component";
import { MatSelectModule } from "@angular/material/select";
import { InterviewsRoutingModule } from "./interviews-routing.module";
import { ReactiveFormsModule } from "@angular/forms";
import { MatInputModule } from "@angular/material/input";
import { MatDatepickerModule } from "@angular/material/datepicker";
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from "@angular-material-components/datetime-picker";

@NgModule({
  declarations: [
    InterviewsComponent,
    InterviewItemComponent,
    AddInterviewComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    RouterLink,
    MatCardModule,
    HomeModule,
    MatButtonModule,
    MatSelectModule,
    InterviewsRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule
  ]
})
export class InterviewsModule { }
