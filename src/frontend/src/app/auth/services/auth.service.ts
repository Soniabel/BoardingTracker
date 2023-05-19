import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from "rxjs";
import {Router} from "@angular/router";
import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';
import { RegisterRequest } from '../models/register-request';
import { RegisterResponse } from '../models/register-response';
import { Candidate } from 'src/app/candidates/models/candidate';
import { Recruiter } from 'src/app/recruiters/models/recruiter';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient,
    private router: Router) { }

    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    public login(loginRequest: LoginRequest): Observable<LoginResponse> {
      return this.httpClient.post<LoginResponse>(`${environment.baseUrl}/Security/login`, JSON.stringify(loginRequest), this.httpOptions)
        .pipe(map((data) => {
          return data;
        }));
    }

    public register(registerRequest: RegisterRequest): Observable<RegisterResponse> {
      return this.httpClient.post<RegisterResponse>(`${environment.baseUrl}/Security/register`, JSON.stringify(registerRequest), this.httpOptions)
        .pipe(map((data) => {
          return data;
        }));
    }

    public getCandidateByUserGID(userGID: string): Observable<Candidate> {
      return this.httpClient.get<Candidate>(`${environment.baseUrl}/Candidates/candidatebyusergid?userGID=${userGID}`)
        .pipe(map((data) => {
          return data;
        }));
    }

    public getRecruiterByUserGID(userGID: string): Observable<Recruiter> {
      return this.httpClient.get<Recruiter>(`${environment.baseUrl}/Recruiter/recruiterbyusergid?userGID=${userGID}`)
        .pipe(map((data) => {
          return data;
        }));
    }

    public checkData(userGID: string, role: string) {
      if (role === 'candidate') {
        this.getCandidateByUserGID(userGID ?? "").subscribe((data) => {
          if(data != null) {
            localStorage.setItem("FIRSTNAME", data.firstName ?? "");
            localStorage.setItem("LASTNAME", data.lastName ?? "");
            this.router.navigateByUrl('/role-candidate')
          } else {
            this.router.navigateByUrl('/profile-settings/candidate-settings')
          }
        }, (error) => {
          console.log(error)
        });
      } else {
        this.getRecruiterByUserGID(userGID ?? "").subscribe((data) => {
          if(data != null) {
            localStorage.setItem("FIRSTNAME", data.firstName ?? "");
            localStorage.setItem("LASTNAME", data.lastName ?? "");
            this.router.navigateByUrl('/role-recruiter')
          } else {
            this.router.navigateByUrl('/profile-settings/recruiter-settings')
          }
        }, (error) => {
          console.log(error)
        });
      }
    }
}
