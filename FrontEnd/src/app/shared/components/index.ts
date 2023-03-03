import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SolidButtonComponent } from './buttons/solid-button/solid-button.component';
import { CardBasicComponent } from './cards/card-basic/card-basic.component';
import { CardUserComponent } from './cards/card-user/card-user.component';
import { ColComponent } from './columns/col/col.component';
import { RowComponent } from './columns/row/row.component';
import { HijoComponent } from './hijo/hijo.component';
import { HijoaComponent } from './hijoa/hijoa.component';
import { HijobComponent } from './hijob/hijob.component';
import { HookonchangeComponent } from './hookonchange/hookonchange.component';
import { CardLoaderComponent } from './loaders/card-loader/card-loader.component';
import { MmodalComponent } from './modals/mmodal/mmodal.component';
import { NietoaComponent } from './nietoa/nietoa.component';
import { NietobComponent } from './nietob/nietob.component';
import { PadreComponent } from './padre/padre.component';
import { FtTbodyComponent } from './tables/full-table/ft-tbody/ft-tbody.component';
import { FtTfootComponent } from './tables/full-table/ft-tfoot/ft-tfoot.component';
import { FtTheadComponent } from './tables/full-table/ft-thead/ft-thead.component';
import { FullTableComponent } from './tables/full-table/full-table.component';
import { TitleH1Component } from './titles/title-h1/title-h1.component'
import { ToastComponent } from './toast/toast.component';


export const components: any[] = [

    TitleH1Component,
    CardUserComponent,
    CardLoaderComponent,
    HookonchangeComponent,
    BreadcrumbComponent,

    // buttons
    SolidButtonComponent,

    // tables
    FullTableComponent,
    FtTheadComponent,
    FtTbodyComponent,
    FtTfootComponent,

    // card
    CardBasicComponent,
    //columns
    RowComponent ,
    ColComponent,

    //Modal
    MmodalComponent,

    // toast
    ToastComponent,
    HijoComponent,
    PadreComponent, HijoaComponent, HijobComponent, NietoaComponent, NietobComponent,
];

export * from './cards/card-user/card-user.component';
export * from './titles/title-h1/title-h1.component';
export * from './loaders/card-loader/card-loader.component';
export * from './hookonchange/hookonchange.component';
export * from './breadcrumb/breadcrumb.component';
export * from './buttons/solid-button/solid-button.component';
export * from './tables/full-table/ft-tbody/ft-tbody.component';
export * from './tables/full-table/ft-tfoot/ft-tfoot.component';
export * from './tables/full-table/ft-thead/ft-thead.component';
export * from './tables/full-table/full-table.component';
export * from './cards/card-basic/card-basic.component';
export * from './columns/row/row.component';
export * from './columns/col/col.component';
export * from './modals/mmodal/mmodal.component';
export * from './toast/toast.component';
export * from './padre/padre.component';
export * from './hijoa/hijoa.component';
export * from './hijob/hijob.component';
export * from './nietoa/nietoa.component';
export * from './nietob/nietob.component';

