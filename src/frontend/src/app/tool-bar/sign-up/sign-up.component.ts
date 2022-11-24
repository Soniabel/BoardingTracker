import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  public isCandidateFieldsShown: boolean = true;
  public isRecruiterRole: boolean = false;
  public authFormInfo!: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.authFormInfo = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      biography: ['', Validators.required],
      resume: ['', Validators.required],
      image: ['', Validators.required]
    });
  }

  showCandidateFields(): void {
    this.isCandidateFieldsShown = true;
  }

  selectRole(): void {
    if(this.isRecruiterRole) {
      this.isCandidateFieldsShown = false;
    }
  }
}
