import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { InterviewsComponent } from "./interviews.component";
import { AddInterviewComponent } from "./add-interview/add-interview.component";

const routes: Routes = [
  { path: '', component: InterviewsComponent },
  { path: 'create', component: AddInterviewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InterviewsRoutingModule { }
