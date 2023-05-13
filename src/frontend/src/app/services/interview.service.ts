import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { ResponseModel } from "../shared/models/response-model";
import { environment } from "../../environments/environment";
import { Interview } from "../interviews/models/interview";

@Injectable({
  providedIn: 'root'
})
export class InterviewService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Interview[]> {
    return this.httpClient.get<ResponseModel<Interview[]>>(`${environment.baseUrl}/interviews`)
      .pipe(map((data) => {
        return data.items
      }));
  }

  public addInterview(interview: Interview): Observable<Interview> {
    return this.httpClient.post<Interview>(`${environment.baseUrl}/interviews`, interview)
  }
}
