import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { SeniorityLevel } from '../shared/models/seniority-level';
import { ResponseModel } from '../shared/models/response-model';
import { environment } from 'src/environments/environment';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeniorityLevelService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<SeniorityLevel[]> {
    return this.httpClient.get<ResponseModel<SeniorityLevel[]>>(`${environment.baseUrl}/senioritylevels`)
      .pipe(map((data) => {
        return data.items
      }));
  }
}
