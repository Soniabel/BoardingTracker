import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { Recruiter } from "../recruiters/models/recruiter";
import { ResponseModel } from "../shared/models/response-model";
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Recruiter[]> {
    return this.httpClient.get<ResponseModel<Recruiter[]>>(`${environment.baseUrl}/recruiters`)
    .pipe(map((data) => {
      return data.items
    }));
  }
}
