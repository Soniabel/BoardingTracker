import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecruitersComponent } from "./recruiters.component";
import { MatCardModule } from "@angular/material/card";
import { HomeModule } from "../home/home.module";
import { SharedModule } from "../shared/shared.module";
import { RecruitersRoutingModule } from "./recruiters-routing.module";

@NgModule({
  declarations: [
    RecruitersComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    HomeModule,
    SharedModule,
    RecruitersRoutingModule
  ]
})
export class RecruitersModule { }
