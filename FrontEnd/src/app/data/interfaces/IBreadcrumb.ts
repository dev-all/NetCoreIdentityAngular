import { Observable } from "rxjs/internal/Observable";

export interface IBreadcrumb {
  path: string;
  label: Observable<string>;
  icon?: Observable<string>;
}
export interface IBreadcrumbRouteConfig {
  providerKey?: string;
  label?: string;
  icon?: any;
}
// https://ngserve.io/angular-tutorial-creating-a-navigation-module-for-breadcrumb/
