import { createAction, props } from "@ngrx/store";
import { Interview } from "src/app/interviews/models/interview";

export enum InterviewActions {
    GetAllInterviews = '[Interview] Get All',
    GetAllInterviewsSuccess = '[Interview] Get Success',
    GetAllInterviewsFailure = '[Interview] Failure Get'
}

export const GetAllInterviews = createAction(
    InterviewActions.GetAllInterviews
);

export const GetAllInterviewsSuccess = createAction(
    InterviewActions.GetAllInterviewsSuccess,
    props<{ data: Interview[] }>()
);

export const GetAllInterviewsFailure = createAction(
    InterviewActions.GetAllInterviewsFailure,
    props<{ error: string | null }>()
);