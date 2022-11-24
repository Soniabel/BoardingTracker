import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Candidate } from "../candidates/models/candidate";
import { ResponseModel } from "../shared/models/response-model";
import { environment } from "../../environments/environment";
import { Skill } from "../shared/models/skill";

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Candidate[]> {
    return this.httpClient.get<ResponseModel<Candidate[]>>(`${environment.baseUrl}/candidates`)
    .pipe(map((data) => {
      return data.items
    }));
  }

  public getCandidateSkills(id: number): Observable<Skill[]> {
    return  this.httpClient.get<ResponseModel<Skill[]>>(`${environment.baseUrl}/candidates/skills/${id}`)
      .pipe(map((data) => {
        return data.items
      }));
  }
}
