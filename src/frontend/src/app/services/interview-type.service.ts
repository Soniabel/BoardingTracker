import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { ResponseModel } from "../shared/models/response-model";
import { environment } from "../../environments/environment";
import { InterviewType } from "../interviews/models/interview-type";

@Injectable({
  providedIn: 'root'
})
export class InterviewTypeService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<InterviewType[]> {
    return this.httpClient.get<ResponseModel<InterviewType[]>>(`${environment.baseUrl}/interviewtypes`)
      .pipe(map((data) => {
        return data.items
      }));
  }
}
