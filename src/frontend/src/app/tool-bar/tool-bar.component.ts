import { Component } from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import { SignInComponent } from "./sign-in/sign-in.component";
import { SignUpComponent } from "./sign-up/sign-up.component";

@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent {

  constructor(private authDialogContainer: MatDialog) { }

  openAuthDialog(isSignUp: boolean): void {
    if (isSignUp) {
      this.authDialogContainer.open(SignUpComponent, { panelClass: 'auth-dialog-container' });
    }
    else {
      this.authDialogContainer.open(SignInComponent, { panelClass: 'auth-dialog-container' });
    }
  }
}
