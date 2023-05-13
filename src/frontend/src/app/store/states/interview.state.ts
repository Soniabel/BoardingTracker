import { Interview } from '../../interviews/models/interview'

export const INTERVIEWS_FEATURE_KEY = 'interviews';

export interface InterviewState {
    interviews: Interview[];
    loaded: boolean;
    error?: string | null;
}

export const initialInterviewState: InterviewState = {
    interviews: [],
    loaded: false,
    error: null
}