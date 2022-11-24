import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { VacanciesComponent } from "./vacancies.component";
import { AddVacancyComponent } from "./add-vacancy/add-vacancy.component";

const routes: Routes = [
  { path: '', component: VacanciesComponent },
  { path: 'create', component: AddVacancyComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VacanciesRoutingModule { }
