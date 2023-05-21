import { Component, OnInit, Inject } from '@angular/core';
import { Candidate } from "../models/candidate";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Skill } from "../../shared/models/skill";
import { Observable } from "rxjs";
import { CandidateService } from "../../services/candidate.service";


@Component({
  selector: 'app-candidate-item',
  templateUrl: './candidate-item.component.html',
  styleUrls: ['./candidate-item.component.scss']
})
export class CandidateItemComponent implements OnInit {
  public candidate!: Candidate;
  public skills$!: Observable<Skill[]>;

  constructor( @Inject(MAT_DIALOG_DATA) public data: any,
               private candidateService: CandidateService) { }

  ngOnInit(): void {
    this.candidate = this.data.candidate;
    //this.skills$ = this.candidateService.getCandidateSkills(this.candidate.userId);
  }
}
