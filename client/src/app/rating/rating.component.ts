import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css'],
})
export class RatingComponent implements OnInit {
  @Input() value: number = 0;
  @Input() text: string = '';

  constructor() {}

  ngOnInit(): void {}
}
