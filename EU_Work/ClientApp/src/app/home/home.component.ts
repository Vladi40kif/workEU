import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public onTop: number;

  @HostListener('window:scroll', ['$event']) 
    doSomething(event) {
      this.onTop = window.pageYOffset;
      //console.log("Scroll Event", window.pageYOffset );
    }

}
