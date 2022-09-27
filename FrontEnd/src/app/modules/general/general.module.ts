import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FeahterIconModule } from '@core/feather-icon/feather-icon.module';

import {
  NgbAccordionModule,
  NgbDropdownModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';

import { GeneralComponent } from './general.component';
import { BlankComponent } from './blank/blank.component';
import { FaqComponent } from './faq/faq.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { ProfileComponent } from './profile/profile.component';
import { PricingComponent } from './pricing/pricing.component';
import { TimelineComponent } from './timeline/timeline.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '@share/shared.module';
import { AuthGuard } from '@core/guard/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'blank-page',
    canActivate: [AuthGuard],
    //pathMatch: 'full'      /// esta propiedad es para redirigir exactamente a la propiedad redirectTo
  },
  {
    path: 'blank-page',
    component: BlankComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'faq',
    component: FaqComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'invoice',
    component: InvoiceComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'pricing',
    component: PricingComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'timeline',
    component: TimelineComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  declarations: [
    GeneralComponent,
    BlankComponent,
    FaqComponent,
    InvoiceComponent,
    ProfileComponent,
    PricingComponent,
    TimelineComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FeahterIconModule,
    NgbAccordionModule,
    NgbDropdownModule,
    NgbTooltipModule,
    SharedModule,
  ],
})
export class GeneralModule {}
