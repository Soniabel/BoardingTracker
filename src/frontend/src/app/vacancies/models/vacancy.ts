import { SeniorityLevel } from "../../shared/models/seniority-level";
import { VacancyType } from "./vacancy-type";
import { VacancyStatus } from "./vacancy-status";
import { Recruiter } from "../../recruiters/models/recruiter";

export interface Vacancy {
  id: number;
  title: string;
  description: string;
  salary: number;
  seniorityLevel: SeniorityLevel;
  vacancyType: VacancyType;
  vacancyStatus: VacancyStatus;
  recruiter: Recruiter;
}
