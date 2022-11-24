import { Component, OnInit } from '@angular/core';
import { Recruiter } from "./models/recruiter";
import { RecruiterService } from "../services/recruiter.service";
import { Observable } from "rxjs";

@Component({
  selector: 'app-recruiters',
  templateUrl: './recruiters.component.html',
  styleUrls: ['./recruiters.component.scss']
})
export class RecruitersComponent implements OnInit {
  public recruiters$!: Observable<Recruiter[]>;

  constructor(private recruiterService: RecruiterService) { }

  ngOnInit(): void {
    this.recruiters$ = this.recruiterService.getAll();
  }
}
