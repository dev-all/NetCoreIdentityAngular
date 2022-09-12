import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { CardUserComponent } from './cards/card-user/card-user.component';
import { HookonchangeComponent } from './hookonchange/hookonchange.component';
import { CardLoaderComponent } from './loaders/card-loader/card-loader.component';
import { TitleH1Component } from './titles/title-h1/title-h1.component'


export const components: any[] = [
    TitleH1Component,
    CardUserComponent,
    CardLoaderComponent,
    HookonchangeComponent,
    BreadcrumbComponent,

];

export * from './cards/card-user/card-user.component';
export * from './titles/title-h1/title-h1.component';
export * from './loaders/card-loader/card-loader.component';
export * from './hookonchange/hookonchange.component';
export * from './breadcrumb/breadcrumb.component';

