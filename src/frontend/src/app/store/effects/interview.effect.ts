import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, map, of, switchMap } from "rxjs";
import { Interview } from "src/app/interviews/models/interview";
import { InterviewService } from "src/app/services/interview.service";
import * as interviewActions from "../actions/interview.action";

@Injectable()
export class InterviewEffects {
  booksService: any;
    constructor(private readonly actions$: Actions,
                private service: InterviewService) {}

public readonly getAllInterviews$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(interviewActions.GetAllInterviews),
      switchMap(() => this.service.getAll().pipe( map((data: Interview[]) => interviewActions.GetAllInterviewsSuccess({ data })))),
      catchError((error: string | null) =>
        of(interviewActions.GetAllInterviewsFailure({ error }))
      )
    );
  });
}