import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Candidate } from 'src/app/candidates/models/candidate';
import { Recruiter } from 'src/app/recruiters/models/recruiter';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileSettingsService {

  constructor(private httpClient: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public createRecruiter(recruiterRequest: Recruiter): Observable<Recruiter> {
    return this.httpClient.post<Recruiter>(`${environment.baseUrl}/Recruiter`, JSON.stringify(recruiterRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }
  public createCandidate(candidateRequest: Candidate): Observable<Candidate> {
    return this.httpClient.post<Candidate>(`${environment.baseUrl}/Candidates`, JSON.stringify(candidateRequest), this.httpOptions)
      .pipe(map((data) => {
        return data;
      }));
  }
}
