import { ChangeDetectionStrategy, Component, Inject, OnInit } from '@angular/core';
import { Interview } from "../models/interview";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
  selector: 'app-interview-item',
  templateUrl: './interview-item.component.html',
  styleUrls: ['./interview-item.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InterviewItemComponent implements OnInit {
  public interview!: Interview;

  constructor( @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.interview = this.data.interview;
  }
}
