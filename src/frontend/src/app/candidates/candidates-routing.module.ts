import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CandidatesComponent } from "./candidates.component";

const routes: Routes = [
  { path: '', component: CandidatesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidatesRoutingModule { }
