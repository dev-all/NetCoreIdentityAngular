import { CoreModule } from '@core/core.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorPageComponent } from '@modules/error-page/error-page.component';

import { LayoutModule } from '@layout/layout.module';

import { SharedModule } from './shared/shared.module';
import { DATE_PIPE_DEFAULT_TIMEZONE, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    AppComponent,
    ErrorPageComponent,
  ],
  imports: [
    BrowserModule,
    // Core
    CoreModule,
    SharedModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    NgbModule,
    //FontAwesomeModule

  ],
  providers: [{
    provide:[ LocationStrategy,
            {provide: DEFAULT_CURRENCY_CODE, useValue: 'ARS' },
            {provide: LOCALE_ID, useValue: 'es-AR'},
            {provide: DATE_PIPE_DEFAULT_TIMEZONE, useValue: 'UTC-3' }
          ],
    useClass: PathLocationStrategy
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
