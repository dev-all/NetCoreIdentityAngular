import { Component, Inject, OnInit, Renderer2 ,} from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';

import { ColorPickerService } from 'ngx-color-picker';
import { DataService } from '@share/services/data/data.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit{


  mensaje: string = 'Navbar';
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private router: Router,
    private dataService: DataService
  ) { }


  ngOnInit() {
     this.dataService.nombre$.subscribe( texto => {
       this.mensaje = texto;
       console.log('navbar:', texto);
       });

      // this.dataService.nombre$.emit('hijo!');
   }




  /**
   * Sidebar toggle on hamburger button click
   */
  toggleSidebar(e: Event) {
    e.preventDefault();
    this.document.body.classList.toggle('sidebar-open');
  }

  /**
   * Logout
   */
  onLogout(e: Event) {
    e.preventDefault();
    localStorage.removeItem('isLoggedin');

    if (!localStorage.getItem('isLoggedin')) {
      this.router.navigate(['/auth/login']);
    }
  }

}
