import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolBarModule} from './tool-bar/tool-bar.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { VacanciesModule } from "./vacancies/vacancies.module";
import { RecruitersModule } from "./recruiters/recruiters.module";
import { InterviewsModule } from "./interviews/interviews.module";
import { CandidatesModule } from "./candidates/candidates.module";
import { SharedModule } from "./shared/shared.module";
import { StoreModule } from '@ngrx/store';
import { reducerInterview } from './store/reducers/interview.reducer';
import { EffectsModule } from '@ngrx/effects';
import { InterviewEffects } from './store/effects/interview.effect';
import { environment } from 'src/environments/environment';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    ToolBarModule,
    NgbModule,
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    VacanciesModule,
    RecruitersModule,
    InterviewsModule,
    CandidatesModule,
    SharedModule,
    StoreModule.forRoot({interviews: reducerInterview}),
    EffectsModule.forRoot([InterviewEffects]),
    !environment.production ? StoreDevtoolsModule.instrument() : []
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
