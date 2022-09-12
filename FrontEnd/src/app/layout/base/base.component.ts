import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router, RouteConfigLoadStart, RouteConfigLoadEnd } from '@angular/router';


@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.scss']
})
export class BaseComponent implements AfterViewInit, OnInit {

  isLoading: boolean = true;

  constructor(private router: Router) {

   /// Spinner for lazyload modules
    router.events.forEach((event) => {

      if (event instanceof RouteConfigLoadStart) {
        this.isLoading = true;

      } else if (event instanceof RouteConfigLoadEnd) {
        this.isLoading = false;

      }
    });


  }
  ngAfterViewInit(): void {
    // solo se visualiza cuando se recarga la pagina base
    // por ende no es para todos los view
    setTimeout(() => {
    this.isLoading = false;
    }, 1000);

    console.log('afterViewInit baseComponent');
  }

  ngOnInit(): void {
    console.log(' OnInit baseComponent');
  }

}
