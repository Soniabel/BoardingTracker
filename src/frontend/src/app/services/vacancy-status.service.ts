import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { VacancyStatus } from '../vacancies/models/vacancy-status';
import { map, Observable } from 'rxjs';
import { ResponseModel } from '../shared/models/response-model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VacancyStatusService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<VacancyStatus[]> {
    return this.httpClient.get<ResponseModel<VacancyStatus[]>>(`${environment.baseUrl}/vacancystatuses`)
      .pipe(map((data) => {
        return data.items
      }));
  }
}
