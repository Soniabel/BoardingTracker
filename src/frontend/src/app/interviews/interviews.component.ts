import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { Interview } from "./models/interview";
import { MatDialog } from "@angular/material/dialog";
import { InterviewItemComponent } from "./interview-item/interview-item.component";
import { InterviewState } from '../store/states/interview.state';
import { Store } from '@ngrx/store';
import { selectAllInterviews } from '../store/selectors/interview.selector';
import * as interviewActions from "../store/actions/interview.action";

@Component({
  selector: 'app-interviews',
  templateUrl: './interviews.component.html',
  styleUrls: ['./interviews.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InterviewsComponent implements OnInit {
  public interviews$!: Observable<Interview[]>;

  constructor(private interviewDialogContainer: MatDialog,
              private store: Store<InterviewState>) {
                this.interviews$ = this.store.select((selectAllInterviews));
               }

  ngOnInit(): void {
    this.store.dispatch(interviewActions.GetAllInterviews());
  }

  openInterviewItem(interview: Interview): void {
    this.interviewDialogContainer.open(InterviewItemComponent, {
      panelClass: 'interview-modal-container',
      width: '40rem',
      data: { interview: interview }
    });
  }
}
