import { Component, HostListener } from '@angular/core';
import { trigger, state, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],

})
export class NavMenuComponent {
  
  public nonTop: number;

  @HostListener('window:scroll', ['$event']) detect(event) {
      this.nonTop = window.pageYOffset;
    }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
