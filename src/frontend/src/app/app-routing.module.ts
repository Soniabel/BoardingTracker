import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from "./shared/not-found/not-found.component";

const routes: Routes = [
  { path:'', component: HomeComponent },
  { path: 'vacancies',
    loadChildren: () => import('./vacancies/vacancies.module').then((m) => m.VacanciesModule)
  },
  { path: 'candidates',
    loadChildren: () => import('./candidates/candidates.module').then((m) => m.CandidatesModule)
  },
  { path: 'recruiters',
    loadChildren: () => import('./recruiters/recruiters.module').then((m) => m.RecruitersModule)
  },
  { path: 'interviews',
    loadChildren: () => import('./interviews/interviews.module').then((m) => m.InterviewsModule)
  },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
