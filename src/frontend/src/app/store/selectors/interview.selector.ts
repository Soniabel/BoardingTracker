import { createFeatureSelector, createSelector, State } from "@ngrx/store";
import { InterviewState, INTERVIEWS_FEATURE_KEY } from "../states/interview.state";

export const selectInterviewState = createFeatureSelector<InterviewState>(INTERVIEWS_FEATURE_KEY);

export const selectInterviewLoaded = createSelector(
  selectInterviewState,
  (state: InterviewState) => state.loaded
);

export const selectInterviewError = createSelector(
    selectInterviewState,
    (state: InterviewState) => state.error
  );

export const selectAllInterviews = createSelector(
    selectInterviewState,
    (state: InterviewState) => state.interviews);