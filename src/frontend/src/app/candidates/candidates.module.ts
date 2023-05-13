import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidatesComponent } from "./candidates.component";
import { CandidateItemComponent } from "./candidate-item/candidate-item.component";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";
import { HomeModule } from "../home/home.module";
import { SharedModule } from "../shared/shared.module";
import { CandidatesRoutingModule } from "./candidates-routing.module";

@NgModule({
  declarations: [
    CandidatesComponent,
    CandidateItemComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    HomeModule,
    SharedModule,
    CandidatesRoutingModule
  ]
})
export class CandidatesModule { }
