import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appCardShadow]',
})

export class CardShadowDirective {
  constructor(private el: ElementRef, private renderer: Renderer2) {}

  @HostListener("mouseenter") mouseover(eventData: Event) {
    this.renderer.setStyle(
      this.el.nativeElement,
      "box-shadow",
      "0rem 0.125rem 0.25rem 0rem #A49D9D, 0rem 0.125rem 1rem 0rem #A49D9D"
    );
  }

  @HostListener("mouseleave") mouseleave(eventData: Event) {
    this.renderer.setStyle(
      this.el.nativeElement,
      "box-shadow",
      "0.625rem 0.3125rem 0.3125rem transparent"
    );
  }
}
