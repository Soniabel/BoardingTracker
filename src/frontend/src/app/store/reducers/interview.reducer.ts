import { Action, createReducer, on } from "@ngrx/store";
import { initialInterviewState, InterviewState } from "../states/interview.state";
import * as interviewActions from "../actions/interview.action";

const interviewReducer = createReducer(
    initialInterviewState,
    on(interviewActions.GetAllInterviews, (state) => ({
        ...state, loaded: false, error: null})),
    on(interviewActions.GetAllInterviewsSuccess, (state, { data }) => ({
        ...state,
        interviews: data,
        loaded: true,
        error: null
    })),
    on(interviewActions.GetAllInterviewsFailure, (state, { error }) => ({ 
        ...state, loaded: false, error }))
);

export function reducerInterview(state: InterviewState | undefined, action: Action){
    return interviewReducer(state, action);
  }