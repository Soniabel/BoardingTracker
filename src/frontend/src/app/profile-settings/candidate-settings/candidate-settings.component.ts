import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Candidate } from 'src/app/candidates/models/candidate';
import { ProfileSettingsService } from '../services/profile-settings.service';

@Component({
  selector: 'app-candidate-settings',
  templateUrl: './candidate-settings.component.html',
  styleUrls: ['./candidate-settings.component.scss']
})
export class CandidateSettingsComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;
  public phoneNumber: string | null = null;
  public biography: string | null = null;
  public resumeUrl: string | null = null;
  public profileImageUrl: string | null = null;
  public email: string | null = null;
  public candidateRequest!: Candidate;
  
  constructor(private profileSettingsService: ProfileSettingsService,
    private router: Router) { }

  ngOnInit(): void {
    console.log("candidate settings");
  }

  public handleClick(): void {
    this.candidateRequest = {
      firstName: '',
      lastName: '',
      phoneNumber: '',
      biography: '',
      resumeUrl: '',
      profileImageUrl: '',
      email: '',
      userId: ''
    }

    this.candidateRequest.firstName = this.firstName;
    this.candidateRequest.lastName = this.lastName;
    this.candidateRequest.phoneNumber = this.phoneNumber;
    this.candidateRequest.biography = this.biography;
    this.candidateRequest.resumeUrl = this.resumeUrl;
    this.candidateRequest.profileImageUrl = this.profileImageUrl;
    this.candidateRequest.userId = localStorage.getItem("USER_ID");

    this.profileSettingsService.createCandidate(this.candidateRequest).subscribe((data) =>
    {
      localStorage.setItem("FIRSTNAME", data.firstName ?? "");
      localStorage.setItem("LASTNAME", data.lastName ?? "");
      this.router.navigate(['/role-candidate'])
    }, (error) => {
      console.log(error);
    })
  }

}
