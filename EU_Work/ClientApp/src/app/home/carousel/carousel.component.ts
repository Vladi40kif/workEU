import { Component, OnInit, Input } from '@angular/core';
import { trigger, transition, style, animate } from "@angular/animations";

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss'],
  animations: [
    trigger('carouselAnimation', [
      transition('void => *', [
        style({ opacity: 0 }),
        animate('300ms', style({ opacity: 1 }))
      ]),
      transition('* => void', [
        animate('300ms', style({ opacity: 0 }))
      ])
    ])
  ]
})
export class CarouselComponent implements OnInit {
  public slides = [
    { src: 'assets/img/slider/work.jpg', title: 'Title 1' },
    { src: 'assets/img/slider/insurance.jpg', title: 'Title 2' },
    { src: 'assets/img/slider/passport.jpg', title: 'Title 3' },
    { src: 'assets/img/slider/taks.jpg', title: 'Title 4' }
  ];

  constructor() { }

  ngOnInit(): void {
    setInterval( x => this.onNextClick(), 7000);
  }

  currentSlide = 0;

  onPreviousClick() {
    const previous = this.currentSlide - 1;
    this.currentSlide = previous < 0 ? this.slides.length - 1 : previous;
  }

  onNextClick() {
    const next = this.currentSlide + 1;
    this.currentSlide = next == this.slides.length ? 0 : next;
  }

}
