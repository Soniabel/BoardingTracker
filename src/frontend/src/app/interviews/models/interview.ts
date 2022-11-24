import { Recruiter } from "../../recruiters/models/recruiter";
import { Vacancy } from "../../vacancies/models/vacancy";
import { InterviewType } from "./interview-type";
import { Candidate } from "../../candidates/models/candidate";

export interface Interview {
  id: number;
  title: string;
  startTime: string;
  endTime: string;
  vacancy: Vacancy;
  recruiter: Recruiter;
  candidate: Candidate;
  interviewType: InterviewType;
}
