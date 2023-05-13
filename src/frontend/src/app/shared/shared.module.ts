import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardShadowDirective } from "./card-shadow.directive";
import { NotFoundComponent } from './not-found/not-found.component';


@NgModule({
  declarations: [
    CardShadowDirective,
    NotFoundComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CardShadowDirective
  ]
})
export class SharedModule { }
