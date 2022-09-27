import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-loader',
  templateUrl: './card-loader.component.html',
  styleUrls: ['./card-loader.component.scss'],
})
export class CardLoaderComponent implements OnInit {
  // input style
  @Input() imageSize = 70;
  @Input() barHeight = 15;
  @Input() bars = 1;

  // final properties
  public totalBars: { width: string }[] = [];
  public finalStyleImage = {};
  public finalHeightBar = '0';

  constructor() {}

  ngOnInit(): void {
    // console.log("loaderrrr");
    // total bar
    for (let index = 0; index < this.bars; index++) {
      const width = Math.floor(Math.random() * (100 - 60)) + 60;
      this.totalBars.push({ width: `${width}%` });
    }
    // img style
    this.finalStyleImage = {
      width: `${this.imageSize}px`,
      height: `${this.imageSize}px`,
    };

    this.finalHeightBar = `${this.barHeight}px`;
  }
}
