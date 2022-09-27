import {
  DATE_PIPE_DEFAULT_TIMEZONE,
  getLocaleCurrencyCode,
  getLocaleCurrencyName,
  getLocaleCurrencySymbol,
  getLocaleDirection,
  getLocaleEraNames,
  getLocaleId,
  TranslationWidth,
} from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit, Optional } from '@angular/core';

@Component({
  selector: 'app-pipes',
  templateUrl: './pipes.component.html',
  styleUrls: ['./pipes.component.scss'],
})
export class PipesComponent implements OnInit {
  //pipe person
  public obj: any;
  public stringVar: string;
  public dateVar: number;
  public currencyVar: number;
  public decimalVar: number;

  public user: {
    name: string;
    gender: 'M' | 'F';
    role: string;
  };

  curr = getLocaleCurrencyName(this.locale);
  code = getLocaleCurrencyCode(this.locale);
  sym = getLocaleCurrencySymbol(this.locale);
  for = getLocaleId(this.locale);
  dir = getLocaleDirection(this.locale);
  numB: number = 2.4595;

  customText: string = 'Java is to JavaScript what car is to Carpet.';

  constructor(
    @Inject(LOCALE_ID) public locale: string,
    @Inject(DATE_PIPE_DEFAULT_TIMEZONE)
    @Optional()
    private defaultTimezone?: string | null
  ) {
    this.obj = [
      { id: 1, name: 'jose primero', joinDate: 1599935113003 },
      { id: 1, name: 'jose segundo', joinDate: 1599935113003 },
    ];
    this.stringVar = 'Curso de angular ';
    this.dateVar = new Date().getTime();
    this.currencyVar = 15500.99;
    this.decimalVar = 0;

    this.user = {
      name: 'Leonardo',
      gender: 'M',
      role: 'Admin',
    };
  }

  ngOnInit(): void {
    // timer(0, 1000).subscribe(() => {
    //   this.dateVar = (new Date()).getTime();
    // })
  }
}
