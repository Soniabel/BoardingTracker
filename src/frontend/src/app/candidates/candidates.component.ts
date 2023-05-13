import { Component, OnInit } from '@angular/core';
import { Candidate } from "./models/candidate";
import { CandidateService } from "../services/candidate.service";
import { Observable } from "rxjs";
import { MatDialog } from "@angular/material/dialog";
import { CandidateItemComponent } from "./candidate-item/candidate-item.component";

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.scss']
})
export class CandidatesComponent implements OnInit {
  public candidates$!: Observable<Candidate[]>;

  constructor(private candidateService: CandidateService,
              private candidateDialogContainer: MatDialog) { }

  ngOnInit(): void {
    this.candidates$ = this.candidateService.getAll();
  }

  openCandidateItem(candidate: Candidate): void {
    this.candidateDialogContainer.open(CandidateItemComponent, {
      panelClass: 'candidate-modal-container',
      width: '40rem',
      data: { candidate: candidate }
    });
  }
}
