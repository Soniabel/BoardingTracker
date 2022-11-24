import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Vacancy } from "../vacancies/models/vacancy";
import { ResponseModel } from "../shared/models/response-model";
import { environment } from "../../environments/environment";
import { Skill } from "../shared/models/skill";

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Vacancy[]> {
    return this.httpClient.get<ResponseModel<Vacancy[]>>(`${environment.baseUrl}/vacancies`)
      .pipe(map((data) => {
        return data.items
      }));
  }

  public getVacancySkills(id: number): Observable<Skill[]> {
    return  this.httpClient.get<ResponseModel<Skill[]>>(`${environment.baseUrl}/vacancies/skills/${id}`)
      .pipe(map((data) => {
        return data.items
      }));
  }

  public addVacancy(vacancy: Vacancy): Observable<Vacancy> {
    return this.httpClient.post<Vacancy>(`${environment.baseUrl}/vacancies`, vacancy)
  }
}
