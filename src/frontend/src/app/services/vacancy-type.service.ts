import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { VacancyType } from '../vacancies/models/vacancy-type';
import { ResponseModel } from '../shared/models/response-model';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VacancyTypeService {

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<VacancyType[]> {
    return this.httpClient.get<ResponseModel<VacancyType[]>>(`${environment.baseUrl}/vacancytypes`)
      .pipe(map((data) => {
        return data.items
      }));
  }
}
